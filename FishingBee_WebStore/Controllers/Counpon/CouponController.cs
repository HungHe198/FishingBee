using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Data_FishingBee.ContextFile;
using Data_FishingBee.Models;

namespace Data_FishingBee.Controllers
{
    public class CouponController : Controller
    {
        private readonly FishingBeeDbContext _context;

        public CouponController(FishingBeeDbContext context)
        {
            _context = context;
        }

        // Danh sách mã giảm giá
        public async Task<IActionResult> Index()
        {
            var coupons = await _context.Coupons.OrderByDescending(x=>x.CreatedTime).ToListAsync();
            return View(coupons);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var coupon = await _context.Coupons.FirstOrDefaultAsync(c => c.Id == id);
            if (coupon == null)
                return NotFound();

            // Kiểm tra trạng thái và nếu cần thiết, thay đổi trạng thái
            if (coupon.DateEnd < DateTime.Now.Date)
            {
                coupon.Status = "Vô hiệu hóa";
            }

            return View(coupon);
        }


        // Hiển thị form tạo mới
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Coupon coupon)
        {
            if (coupon.DateStart < DateTime.Now.Date)
            {
                ModelState.AddModelError("DateStart", "Ngày bắt đầu không được nhỏ hơn ngày hiện tại.");
            }
            if (coupon.DateStart >= coupon.DateEnd)
            {
                ModelState.AddModelError("DateStart", "Ngày bắt đầu không được lớn hơn hoặc bằng ngày kết thúc.");
            }
            if (coupon.Percent <= 0 || coupon.Percent >= 40)
            {
                ModelState.AddModelError("Percent", "Phần trăm giảm phải lớn hơn 0 và nhỏ hơn 90.");
            }
            if (coupon.QuantityAvailable <= 0)
            {
                ModelState.AddModelError("QuantityAvailable", "Số lượng phải lớn hơn 0.");
            }
            if (ModelState.IsValid)
            {
                coupon.Status = "Hoạt động";
                if (coupon.DateEnd < DateTime.Now.Date)
                {
                    coupon.Status = "Vô hiệu hóa";
                }

                if (coupon.DateStart < DateTime.Now.Date)
                {
                    coupon.Status = "Vô hiệu hóa";
                }
                coupon.Id = Guid.NewGuid();
                coupon.CreatedTime = DateTime.Now; 
                _context.Coupons.Add(coupon);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(coupon);
        }



        public async Task<IActionResult> Edit(Guid id)
        {
            var coupon = await _context.Coupons.FindAsync(id);
            if (coupon == null)
                return NotFound();

            return View(coupon);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Coupon coupon)
        {
            // Kiểm tra nếu ID không khớp
            if (id != coupon.Id)
                return NotFound();

            // Kiểm tra ngày bắt đầu không được nhỏ hơn ngày hiện tại
            if (coupon.DateStart < DateTime.Now.Date)
            {
                ModelState.AddModelError("DateStart", "Ngày bắt đầu không được nhỏ hơn ngày hiện tại.");
            }

            // Kiểm tra ngày bắt đầu không được lớn hơn hoặc bằng ngày kết thúc
            if (coupon.DateStart >= coupon.DateEnd)
            {
                ModelState.AddModelError("DateStart", "Ngày bắt đầu không được lớn hơn hoặc bằng ngày kết thúc.");
            }

            // Kiểm tra phần trăm giảm
            if (coupon.Percent <= 0 || coupon.Percent >= 40)
            {
                ModelState.AddModelError("Percent", "Phần trăm giảm phải lớn hơn 0 và nhỏ hơn 40.");
            }

            // Kiểm tra số lượng phải lớn hơn 0
            if (coupon.QuantityAvailable <= 0)
            {
                ModelState.AddModelError("QuantityAvailable", "Số lượng phải lớn hơn 0.");
            }

            // Thiết lập trạng thái
            if (!ModelState.IsValid)
            {
                return View(coupon);
            }

            // Kiểm tra và thay đổi trạng thái nếu ngày kết thúc đã qua
            if (coupon.DateEnd < DateTime.Now.Date)
            {
                coupon.Status = "Vô hiệu hóa";
            }
            else
            {
                coupon.Status = "Hoạt động"; // Trạng thái vẫn là "Hoạt động" nếu còn hiệu lực
            }

            // Cập nhật thời gian sửa đổi
            coupon.ModifiedTime = DateTime.Now;

            // Cập nhật vào database
            _context.Update(coupon);
            await _context.SaveChangesAsync();

            // Quay lại trang danh sách
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(Guid id)
        {
            var coupon = await _context.Coupons.FindAsync(id);
            if (coupon == null)
                return NotFound();

            return View(coupon);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var coupon = await _context.Coupons.FindAsync(id);
            if (coupon != null)
            {
                _context.Coupons.Remove(coupon);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
