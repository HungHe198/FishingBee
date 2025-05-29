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
    public async Task<IActionResult> Details(Guid id)
    {
        var bill = await _repoBill.GetById(id);
        if (bill == null)
        {
            return NotFound();
        }

        var billDetails = await _repoBillDetail.GetAllQueryable()
            .Where(bd => bd.BillId == id)
            .Include(bd => bd.ProductDetail) // để lấy thông tin sản phẩm
            .Include(bd=>bd.ProductDetail)
                .ThenInclude(pd=>pd.Product)
            .ToListAsync();

        ViewBag.CustomerName = bill.CustomerName;
        ViewBag.CustomerPhoneNumber = bill.CustomerPhone;
        ViewBag.BillStatus = bill.Status;

        return View(billDetails);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateStatus(Guid id)
    {
        var bill = await _repoBill.GetById(id);
        if (bill == null) return NotFound();

        var oldStatus = bill.Status;

        // Nếu hóa đơn đã hủy thì không nâng nữa
        if (oldStatus == "4")
        {
            TempData["Error"] = "Đơn hàng đã hủy, không thể thay đổi trạng thái.";
            return RedirectToAction(nameof(Index));
        }

        // Xác định trạng thái mới dựa trên thứ tự
        string newStatus = oldStatus switch
        {
            "1" => "2",
            "2" => "3",
            "3" => "0",
            _ => oldStatus // nếu đã 4 hoặc không xác định thì giữ nguyên
        };

        // Nếu không có thay đổi, bỏ qua
        if (newStatus == oldStatus)
        {
            TempData["Info"] = "Trạng thái đã đạt mức cao nhất hoặc không hợp lệ.";
            return RedirectToAction(nameof(Index));
        }

        // Nếu từ 1 → 2, kiểm tra tồn kho
        if (oldStatus == "1" && newStatus == "2")
        {
            var billDetails = await _repoBillDetail.GetAllQueryable()
                .Where(bd => bd.BillId == id)
                .ToListAsync();

            foreach (var detail in billDetails)
            {
                var productDetail = await _repoPD.GetById(detail.ProductDetailId);
                if (productDetail == null) continue;

                if (productDetail.Stock < detail.Amount)
                {
                    TempData["Error"] = $"Sản phẩm '{productDetail.Description}' không đủ hàng (còn {productDetail.Stock}, cần {detail.Amount}).";
                    return RedirectToAction(nameof(Index));
                }
            }

            // Sau khi check đủ, mới trừ kho
            foreach (var detail in billDetails)
            {
                var productDetail = await _repoPD.GetById(detail.ProductDetailId);
                if (productDetail == null) continue;

                productDetail.Stock -= detail.Amount;
                await _repoPD.Update(productDetail.Id, productDetail);
            }
        }

        bill.Status = newStatus;
        bill.ModifiedTime = DateTime.Now;
        await _repoBill.Update(id, bill);

        TempData["Success"] = "Cập nhật trạng thái thành công.";
        return RedirectToAction(nameof(Index));
    }
    [HttpPost]
    public IActionResult CancelStatus(Guid id)
    {
        var bill = _repoBill.GetAllQueryable().FirstOrDefault(b => b.Id == id);
        if (bill != null)
        {
            bill.Status = "4";
            _repoBill.Update(bill.Id, bill);
        }
        return RedirectToAction("Index");
    }



}
