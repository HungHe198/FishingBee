using Data_FishingBee.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Security.Cryptography;
using Data_FishingBee.ContextFile;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace FishingBee_WebStore.Controllers.Account
{
    public class AccountController : Controller
    {
        private readonly FishingBeeDbContext _context;

        public AccountController(FishingBeeDbContext context)
        {
            _context = context;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User model)
        {
            if (ModelState.IsValid)
            {
                if (_context.Users.Any(u => u.Username == model.Username))
                {
                    ModelState.AddModelError("Username", "Tên đăng nhập đã tồn tại.");
                    return View(model);
                }
                if (_context.Users.Any(u => u.Email == model.Email))
                {
                    ModelState.AddModelError("Email", "Email này đã được sử dụng. Vui lòng chọn email khác.");
                    return View(model);
                }
                if (_context.Users.Any(u => u.PhoneNumber == model.PhoneNumber))
                {
                    ModelState.AddModelError("PhoneNumber", "Số điện thoại đã được sử dụng. Vui lòng nhập số khác.");
                    return View(model);
                }
                if (!IsPasswordSecure(model.Password, model.Username))
                {
                    ModelState.AddModelError("Password", "Mật khẩu không an toàn. Vui lòng chọn mật khẩu khác.");
                    return View(model);
                }

                // Hash mật khẩu
                model.Password = HashPassword(model.Password);
                model.Id = Guid.NewGuid();
                model.CreatedTime = DateTime.Now;
                model.Status = "Active";

                _context.Users.Add(model);
                _context.SaveChanges();

                var emailService = HttpContext.RequestServices.GetRequiredService<EmailService>();
                await emailService.SendEmailAsync
                (
                    model.Email,
                    "Chào mừng bạn đến với FishingBee",
                    "<h2>Chúc mừng!</h2><p>Bạn đã đăng ký tài khoản thành công.</p>"
                );

                TempData["SuccessMessage"] = "Đăng ký thành công! Kiểm tra email để nhận xác nhận.";
                return RedirectToAction("Login", "Account"); ;
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ToggleUserStatus([FromBody] ToggleUserStatusRequest request)
        {
            if (request == null || request.UserId == Guid.Empty)
            {
                return Json(new { success = false, message = "Dữ liệu không hợp lệ!" });
            }

            var user = await _context.Users.FindAsync(request.UserId);
            if (user == null)
            {
                return Json(new { success = false, message = "Người dùng không tồn tại!" });
            }

            // Đảo trạng thái
            user.Status = user.Status == "Active" ? "Inactive" : "Active";
            user.ModifiedTime = DateTime.Now;

            await _context.SaveChangesAsync();

            return Json(new { success = true, newStatus = user.Status });
        }

        // Định nghĩa request model
        public class ToggleUserStatusRequest
        {
            public Guid UserId { get; set; }
        }

        private bool IsPasswordSecure(string password, string username)
        {
            if (password.ToLower() == username.ToLower()) return false;
            if (password.Length < 8) return false;
            bool hasLetter = password.Any(char.IsLetter);
            bool hasDigit = password.Any(char.IsDigit);
            bool hasSpecialChar = password.Any(ch => !char.IsLetterOrDigit(ch));
            return hasLetter && hasDigit && hasSpecialChar;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var hashedPassword = HashPassword(password);
            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == hashedPassword);
            var admin = _context.Admins.FirstOrDefault(a => a.Username == username && a.Password == password);
            if (user != null && user.Status == "Inactive")
            {
                ViewBag.ErrorMessage = "Tài khoản của bạn đã bị khóa. Vui lòng liên hệ quản trị viên.";
                return View();
            }

            if (user != null || admin != null)
            {
                var role = user != null ? "User" : "Admin";

                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.NameIdentifier, (user?.Id ?? admin?.Id).ToString()),
            new Claim(ClaimTypes.Role, role)
        };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(30)
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties
                );

                return RedirectToAction("Index", "Home");
            }

            ViewBag.ErrorMessage = "Tên đăng nhập hoặc mật khẩu không đúng.";
            return View();
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }



    }
}
