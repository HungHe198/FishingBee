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
                    ModelState.AddModelError("SDT", "Số điện thoại đã được sử dụng. Vui lòng nhập số khác.");
                    return View(model);
                }
                if (!IsPasswordSecure(model.Password, model.Username))
                {
                    ModelState.AddModelError("Password", "Mật khẩu không an toàn. Vui lòng chọn mật khẩu khác.");
                    return View(model);
                }

                // Hash mật khẩu trước khi lưu
                model.Password = HashPassword(model.Password);
                model.Id = Guid.NewGuid();
                model.CreatedTime = DateTime.Now;

                _context.Users.Add(model);
                _context.SaveChanges();

                // Lưu thông báo vào TempData
                TempData["SuccessMessage"] = "Đăng ký thành công! Chào mừng bạn đến với hệ thống.";

                // Gửi email thông báo
                var emailService = HttpContext.RequestServices.GetRequiredService<EmailService>();
                string subject = "Chào mừng bạn đến với FishingBee!";
                string body = $"<h2>Xin chào {model.Username},</h2><p>Bạn đã đăng ký thành công trên FishingBee. Cảm ơn bạn đã tham gia!</p>";
                await emailService.SendEmailAsync(model.Email, subject, body);

                return RedirectToAction("Index", "Home");
            }
            return View(model);
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
        public IActionResult Login(string username, string password)
        {
            var hashedPassword = HashPassword(password);
            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == hashedPassword);

            if (user != null)
            {
                HttpContext.Session.SetString("UserId", user.Id.ToString());

                // Lưu thông báo vào TempData
                TempData["SuccessMessage"] = "Đăng nhập thành công! Chào mừng bạn trở lại.";

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
            await HttpContext.SignOutAsync(); // Đăng xuất khỏi authentication cookie
            HttpContext.Session.Clear(); // Xóa session

            return Json(new { success = true, redirectUrl = Url.Action("Index", "Home") });
        }
    }
}
