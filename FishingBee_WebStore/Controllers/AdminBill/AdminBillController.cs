using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data_FishingBee.Models;
using Data_FishingBee.Repositories;
using System.Collections.Immutable;

public class AdminBillController : Controller
{
    private readonly IAllRepositories<Bill> _repoBill;
    private readonly IAllRepositories<BillDetail> _repoBillDetail;
    private readonly IAllRepositories<ProductDetail> _repoPD;

    

    public AdminBillController(IAllRepositories<Bill> repoBill, IAllRepositories<BillDetail> repoBillDetail, IAllRepositories<ProductDetail> repoPD)
    {
        _repoBill = repoBill;
        _repoBillDetail = repoBillDetail;
        _repoPD = repoPD;
    }

    public async Task<IActionResult> Index(string? status)
    {
        var query = _repoBill.GetAllQueryable();

        if (!string.IsNullOrEmpty(status))
            query = query.Where(b => b.Status == status);

        ViewBag.SelectedStatus = status;
        var result = await query.OrderByDescending(b => b.CreatedTime).ToListAsync();
        return View(result);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateStatus(Guid id, string newStatus)
    {
        var bill = await _repoBill.GetById(id);
        if (bill == null) return NotFound();

        var oldStatus = bill.Status;

        // Nếu trạng thái thay đổi, xử lý tồn kho
        if (oldStatus != newStatus)
        {
            // lấy các sản phẩm trong đơn
            var billDetails = await _repoBillDetail.GetAllQueryable()
                .Where(bd => bd.BillId == id)
                .ToListAsync();
            foreach (var detail in billDetails)
            {
                var productDetail = await _repoPD.GetById(detail.ProductDetailId);
                if (productDetail == null) continue;

                // Nếu từ "chờ xác nhận" sang "đã xác nhận" => trừ tồn kho
                if (oldStatus == "1" && newStatus == "2")
                {
                    productDetail.Stock -= detail.Amount;
                }
                // Nếu từ trạng thái đã trừ kho mà chuyển về trạng thái huỷ hoặc chờ => cộng lại kho
                else if ((oldStatus == "2" || oldStatus == "0") && (newStatus == "1" || newStatus == "4"))
                {
                    productDetail.Stock += detail.Amount;
                }

                await _repoPD.Update(productDetail.Id, productDetail);
            }
        }

        bill.Status = newStatus;
        bill.ModifiedTime = DateTime.Now;
        await _repoBill.Update(id, bill);

        return RedirectToAction(nameof(Index));
    }

}
