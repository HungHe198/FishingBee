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

        public async Task<IActionResult> Index()
        {
            var coupons = await _context.Coupons.OrderByDescending(x => x.CreatedTime).ToListAsync();

            foreach (var coupon in coupons)
            {
                if (coupon.QuantityAvailable == 0 || coupon.DateEnd < DateTime.Now.Date)
                {
                    coupon.Status = "Vô hiệu hóa";
                }
                else
                {
                    coupon.Status = "Hoạt động";
                }
            }

            await _context.SaveChangesAsync();

            return View(coupons); // ✅ PHẢI truyền vào View!
        }


        public async Task<IActionResult> Details(Guid id)
        {
            var coupon = await _context.Coupons.FirstOrDefaultAsync(c => c.Id == id);
            if (coupon == null)
                return NotFound();

            if (coupon.QuantityAvailable == 0 || coupon.DateEnd < DateTime.Now.Date)
            {
                coupon.Status = "Vô hiệu hóa";
                await _context.SaveChangesAsync();
            }

            return View(coupon);
        }


        // Hiển thị form tạo mới
        public IActionResult Create()
        {
            return View();
        }
        // Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Coupon coupon)
        {
            // === Kiểm tra dữ liệu trống ===
            if (string.IsNullOrWhiteSpace(coupon.Name))
            {
                ModelState.AddModelError("Name", "Tên mã giảm giá không được để trống.");
            }

            if (coupon.DateStart == default)
            {
                ModelState.AddModelError("DateStart", "Ngày bắt đầu không được để trống.");
            }

            if (coupon.DateEnd == default)
            {
                ModelState.AddModelError("DateEnd", "Ngày kết thúc không được để trống.");
            }

            if (coupon.Percent == 0)
            {
                ModelState.AddModelError("Percent", "Phần trăm giảm không được để trống.");
            }

            if (coupon.MinOfTotalPrice == 0)
            {
                ModelState.AddModelError("MinOfTotalPrice", "Giá trị đơn tối thiểu không được để trống.");
            }

            if (coupon.MaxOfDiscount == 0)
            {
                ModelState.AddModelError("MaxOfDiscount", "Giảm tối đa không được để trống.");
            }

            if (coupon.QuantityAvailable == 0)
            {
                ModelState.AddModelError("QuantityAvailable", "Số lượng không được để trống.");
            }

            // === Nếu dữ liệu hợp lệ mới kiểm tra logic ===
            if (ModelState.IsValid)
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
                    ModelState.AddModelError("Percent", "Phần trăm giảm phải lớn hơn 0 và nhỏ hơn 40.");
                }

                if (coupon.MinOfTotalPrice <= 0)
                {
                    ModelState.AddModelError("MinOfTotalPrice", "Giá trị đơn tối thiểu phải lớn hơn 0.");
                }

                if (coupon.MaxOfDiscount <= 0)
                {
                    ModelState.AddModelError("MaxOfDiscount", "Giảm tối đa phải lớn hơn 0.");
                }

                if (coupon.MaxOfDiscount > coupon.MinOfTotalPrice)
                {
                    ModelState.AddModelError("MaxOfDiscount", "Giảm tối đa không được lớn hơn giá trị đơn tối thiểu.");
                }

                if (coupon.QuantityAvailable <= 0)
                {
                    ModelState.AddModelError("QuantityAvailable", "Số lượng phải lớn hơn 0.");
                }
            }

            // === Nếu không có lỗi, thêm vào DB ===
            if (ModelState.IsValid)
            {
                coupon.Id = Guid.NewGuid();
                coupon.CreatedTime = DateTime.Now;

                coupon.Status = (coupon.QuantityAvailable == 0 || coupon.DateEnd < DateTime.Now.Date)
                    ? "Vô hiệu hóa"
                    : "Hoạt động";

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
            if (id != coupon.Id)
                return NotFound();

            if (string.IsNullOrWhiteSpace(coupon.Name))
            {
                ModelState.AddModelError("Name", "Tên mã giảm giá không được để trống.");
            }
            if (coupon.DateStart == default)
            {
                ModelState.AddModelError("DateStart", "Ngày bắt đầu không được để trống.");
            }
            if (coupon.DateEnd == default)
            {
                ModelState.AddModelError("DateEnd", "Ngày kết thúc không được để trống.");
            }
            if (coupon.Percent == 0)
            {
                ModelState.AddModelError("Percent", "Phần trăm giảm không được để trống.");
            }
            if (coupon.MinOfTotalPrice == 0)
            {
                ModelState.AddModelError("MinOfTotalPrice", "Giá trị đơn tối thiểu không được để trống.");
            }
            if (coupon.MaxOfDiscount == 0)
            {
                ModelState.AddModelError("MaxOfDiscount", "Giảm tối đa không được để trống.");
            }
            if (coupon.QuantityAvailable == 0)
            {
                ModelState.AddModelError("QuantityAvailable", "Số lượng không được để trống.");
            }

            // Các điều kiện logic
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
                ModelState.AddModelError("Percent", "Phần trăm giảm phải lớn hơn 0 và nhỏ hơn 40.");
            }
            if (coupon.QuantityAvailable <= 0)
            {
                ModelState.AddModelError("QuantityAvailable", "Số lượng phải lớn hơn 0.");
            }
            if (coupon.MinOfTotalPrice <= 0)
            {
                ModelState.AddModelError("MinOfTotalPrice", "Giá trị đơn tối thiểu phải lớn hơn 0.");
            }
            if (coupon.MaxOfDiscount <= 0)
            {
                ModelState.AddModelError("MaxOfDiscount", "Giảm tối đa phải lớn hơn 0.");
            }
            if (coupon.MaxOfDiscount > coupon.MinOfTotalPrice)
            {
                ModelState.AddModelError("MaxOfDiscount", "Giảm tối đa không được lớn hơn giá trị đơn tối thiểu.");
            }

            if (!ModelState.IsValid)
            {
                return View(coupon);
            }

            // Cập nhật trạng thái
            if (coupon.QuantityAvailable == 0 || coupon.DateEnd < DateTime.Now.Date)
            {
                coupon.Status = "Vô hiệu hóa";
            }
            else
            {
                coupon.Status = "Hoạt động";
            }

            coupon.ModifiedTime = DateTime.Now;
            _context.Update(coupon);
            await _context.SaveChangesAsync();

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
