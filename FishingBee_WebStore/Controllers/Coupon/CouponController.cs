using Data_FishingBee.ContextFile;
using Data_FishingBee.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FishingBee_WebStore.Controllers
{
    [Authorize] // Chỉ user đã đăng nhập mới có thể truy cập
    public class CouponController : Controller
    {
        private readonly FishingBeeDbContext _context;

        public CouponController(FishingBeeDbContext context)
        {
            _context = context;
        }

        // Cả User và Admin đều có thể xem danh sách mã giảm giá
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> Index()
        {
            var coupons = await _context.Coupons.ToListAsync();
            return View(coupons);
        }

        // Chỉ Admin có thể tạo mã giảm giá
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(Coupon model)
        {
            if (model.Percent <= 0 || model.Percent >= 100)
            {
                ModelState.AddModelError("Percent", "Phần trăm giảm giá phải lớn hơn 0 và nhỏ hơn 100.");
            }

            if (model.DateStart <= DateTime.Now)
            {
                ModelState.AddModelError("DateStart", "Ngày bắt đầu phải lớn hơn ngày hiện tại.");
            }

            if (model.DateEnd <= DateTime.Now)
            {
                ModelState.AddModelError("DateEnd", "Ngày kết thúc phải lớn hơn ngày hiện tại.");
            }

            if (model.DateEnd < model.DateStart)
            {
                ModelState.AddModelError("DateEnd", "Ngày kết thúc không được nhỏ hơn ngày bắt đầu.");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.Id = Guid.NewGuid();
            _context.Coupons.Add(model);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Mã giảm giá đã được tạo thành công!";
            return RedirectToAction(nameof(Index));
        }


        // Chỉ Admin có thể chỉnh sửa mã giảm giá
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var coupon = await _context.Coupons.FindAsync(id);
            if (coupon == null) return NotFound();
            return View(coupon);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(Guid id, Coupon model)
        {
            if (id != model.Id)
                return NotFound();

            if (model.Percent <= 0 || model.Percent >= 100)
            {
                ModelState.AddModelError("Percent", "Phần trăm giảm giá phải lớn hơn 0 và nhỏ hơn 100.");
            }

            if (model.DateStart <= DateTime.Now)
            {
                ModelState.AddModelError("DateStart", "Ngày bắt đầu phải lớn hơn ngày hiện tại.");
            }

            if (model.DateEnd <= DateTime.Now)
            {
                ModelState.AddModelError("DateEnd", "Ngày kết thúc phải lớn hơn ngày hiện tại.");
            }

            if (model.DateEnd < model.DateStart)
            {
                ModelState.AddModelError("DateEnd", "Ngày kết thúc không được nhỏ hơn ngày bắt đầu.");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _context.Update(model);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Mã giảm giá đã được cập nhật!";
            return RedirectToAction(nameof(Index));
        }


        // Chỉ Admin có thể xóa mã giảm giá
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var coupon = await _context.Coupons.FindAsync(id);
            if (coupon == null) return NotFound();
            return View(coupon);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var coupon = await _context.Coupons.FindAsync(id);
            if (coupon != null)
            {
                _context.Coupons.Remove(coupon);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Mã giảm giá đã bị xóa!";
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
