using Data_FishingBee.Models;
using Data_FishingBee.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FishingBee_WebStore.Controllers.ClientBill
{
    public class BillStatusController : Controller
    {
        private readonly IAllRepositories<Bill> _repoBill;

        public BillStatusController(IAllRepositories<Bill> repoBill)
        {
            _repoBill = repoBill;
        }

        public async Task<IActionResult> Index(string? status)
        {
            // Lấy CustomerId từ Session
            var customerIdJson = HttpContext.Session.GetString("CustomerId");
            if (string.IsNullOrEmpty(customerIdJson))
            {
                return RedirectToAction("Login", "Account"); // Điều hướng nếu chưa đăng nhập
            }
            var customerId = Guid.Parse(customerIdJson);

            // Lấy danh sách hóa đơn của khách hàng hiện tại
            var query = _repoBill.GetAllQueryable()
                                 .Where(b => b.CustomerId == customerId); // 👈 Lọc theo CustomerId

            // Nếu có lọc theo trạng thái
            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(b => b.Status == status);
            }

            ViewBag.SelectedStatus = status;
            var result = await query.OrderByDescending(x=>x.CreatedTime).ToListAsync();
            return View(result);

        }
    }

}
