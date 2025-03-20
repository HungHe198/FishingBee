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
using Microsoft.EntityFrameworkCore;

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
                    ModelState.AddModelError("Email", "Email này đã được sử dụng.");
                    return View(model);
                }

                if (_context.Users.Any(u => u.PhoneNumber == model.PhoneNumber))
                {
                    ModelState.AddModelError("PhoneNumber", "Số điện thoại đã được sử dụng.");
                    return View(model);
                }

                if (!IsPasswordSecure(model.Password))
                {
                    ModelState.AddModelError("Password", "Mật khẩu phải có ít nhất 8 ký tự, chữ hoa, chữ thường, ký tự đặc biệt.");
                    return View(model);
                }

                model.Password = HashPassword(model.Password);
                model.Id = Guid.NewGuid();
                model.CreatedTime = DateTime.Now;
                model.UserType ??= "Customer";
                model.Status = "Active";

                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        // ✅ Thêm User vào database
                        _context.Users.Add(model);
                        await _context.SaveChangesAsync();

                        // ✅ Tạo Customer tương ứng
                        var customer = new Customer
                        {
                            Id = Guid.NewGuid(),
                            UserId = model.Id,
                            CreatedTime = DateTime.Now,
                            LoyaltyPoints = 0
                        };
                        _context.Customers.Add(customer);
                        await _context.SaveChangesAsync();

                        // ✅ Tạo Cart cho Customer mới
                        var cart = new Cart
                        {
                            Id = Guid.NewGuid(),
                            CustomerId = customer.Id,
                            CreatedTime = DateTime.Now,
                            LastUpdateTime = DateTime.Now,
                            Status = "Active"
                        };
                        _context.Carts.Add(cart);
                        await _context.SaveChangesAsync();

                        // ✅ Commit transaction nếu tất cả thành công
                        await transaction.CommitAsync();
                    }
                    catch (Exception)
                    {
                        await transaction.RollbackAsync();
                        ModelState.AddModelError("", "Có lỗi xảy ra trong quá trình đăng ký. Vui lòng thử lại.");
                        return View(model);
                    }
                }

                TempData["SuccessMessage"] = "Đăng ký thành công! Vui lòng cập nhật thông tin cá nhân.";
                return RedirectToAction("CompleteProfile", "Customer", new { userId = model.Id });
            }

            return View(model);
        }


        private bool IsPasswordSecure(string password)
        {
            if (password.Length < 8) return false;

            bool hasUpper = password.Any(char.IsUpper);
            bool hasLower = password.Any(char.IsLower);
            bool hasDigit = password.Any(char.IsDigit);
            bool hasSpecialChar = password.Any(ch => !char.IsLetterOrDigit(ch));

            return hasUpper && hasLower && hasSpecialChar;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);

            if (user != null)
            {
                if (user.Status == "Inactive")
                {
                    ViewBag.ErrorMessage = "Tài khoản của bạn đã bị khóa. Vui lòng liên hệ quản trị viên.";
                    return View();
                }

                if (user.UserType == "Admin" || user.UserType == "Employee")
                {
                    if (user.Password != password)
                    {
                        ViewBag.ErrorMessage = "Tên đăng nhập hoặc mật khẩu không đúng.";
                        return View();
                    }
                }
                else
                {
                    var hashedPassword = HashPassword(password);
                    if (user.Password != hashedPassword)
                    {
                        ViewBag.ErrorMessage = "Tên đăng nhập hoặc mật khẩu không đúng.";
                        return View();
                    }
                }

                //  Lấy CustomerId từ bảng Customers
                var customer = _context.Customers.FirstOrDefault(c => c.UserId == user.Id);
                if (customer != null)
                {
                    //  Lấy CartId từ bảng Carts
                    var cart = _context.Carts.FirstOrDefault(c => c.CustomerId == customer.Id && c.Status == "Active");

                    if (cart != null)
                    {
                        //  Lưu CustomerId & CartId vào Session
                        HttpContext.Session.SetString("CustomerId", customer.Id.ToString());
                        HttpContext.Session.SetString("CartId", cart.Id.ToString());
                    }
                }

                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Role, user.UserType ?? "Customer")
                    };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true
                    };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties
                );

                TempData["SuccessMessage"] = "Đăng nhập thành công!";
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
            return RedirectToAction("Index", "Home");
        }



    }
}
