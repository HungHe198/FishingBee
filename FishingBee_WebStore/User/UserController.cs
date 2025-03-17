using Data_FishingBee.ContextFile;
using Data_FishingBee.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace FishingBee_WebStore.Controllers
{
    [Authorize(Roles = "Admin")] // Chỉ Admin mới có quyền truy cập
    public class UserController : Controller
    {
        private readonly FishingBeeDbContext _context;

        public UserController(FishingBeeDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _context.Users.Select(u => new
            {
                u.Id,
                u.Username,
                u.Password, // Giữ lại vì cả 2 bảng đều có
                u.Email,
                u.PhoneNumber,
                u.Status,
                u.CreatedTime,
                UserType = "User"
            }).ToListAsync();

            var admins = await _context.Admins.Select(a => new
            {
                a.Id,
                a.Username,
                a.Password, // Giữ lại để đồng nhất với User
                Email = (string?)null, // Admin không có Email, để null cho đồng nhất
                PhoneNumber = (string?)null, // Admin không có số điện thoại
                a.Status, // Lấy trạng thái từ database thay vì đặt cứng
                a.CreatedTime,
                UserType = "Admin"
            }).ToListAsync();

            var allUsers = users.Cast<object>().Concat(admins.Cast<object>()).OrderByDescending(u => ((dynamic)u).CreatedTime).ToList();

            return View(allUsers);
        }
        // Hiển thị form tạo mới User
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User model)
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
                model.Id = Guid.NewGuid();
                model.CreatedTime = DateTime.UtcNow;
                model.Status = "Active";

                _context.Users.Add(model);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Tạo User thành công!";
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // Hiển thị form chỉnh sửa User
        public async Task<IActionResult> Edit(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, User model)
        {
            if (id != model.Id) return NotFound();

            if (ModelState.IsValid)
            {
                if (_context.Users.Any(u => u.Username == model.Username && u.Id != model.Id))
                {
                    ModelState.AddModelError("Username", "Tên đăng nhập đã tồn tại.");
                    return View(model);
                }

                if (_context.Users.Any(u => u.Email == model.Email && u.Id != model.Id))
                {
                    ModelState.AddModelError("Email", "Email này đã được sử dụng. Vui lòng chọn email khác.");
                    return View(model);
                }

                if (_context.Users.Any(u => u.PhoneNumber == model.PhoneNumber && u.Id != model.Id))
                {
                    ModelState.AddModelError("PhoneNumber", "Số điện thoại đã được sử dụng. Vui lòng nhập số khác.");
                    return View(model);
                }

                if (!IsPasswordSecure(model.Password, model.Username))
                {
                    ModelState.AddModelError("Password", "Mật khẩu không an toàn. Vui lòng chọn mật khẩu khác.");
                    return View(model);
                }

                model.ModifiedTime = DateTime.UtcNow;

                _context.Update(model);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Cập nhật User thành công!";
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Xóa User thành công!";
            }
            return RedirectToAction(nameof(Index));
        }

        private bool IsPasswordSecure(string password, string username)
        {
            if (password.Length < 8) return false;
            if (password.Contains(username, StringComparison.OrdinalIgnoreCase)) return false;

            bool hasUpper = password.Any(char.IsUpper);
            bool hasLower = password.Any(char.IsLower);
            bool hasDigit = password.Any(char.IsDigit);
            bool hasSpecial = Regex.IsMatch(password, @"[!@#$%^&*(),.?""{}|<>]");

            return hasUpper && hasLower && hasDigit && hasSpecial;
        }
    }
}
