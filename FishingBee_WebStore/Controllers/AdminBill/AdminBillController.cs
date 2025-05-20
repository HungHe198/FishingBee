using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data_FishingBee.Models;
using Data_FishingBee.Repositories;

public class AdminBillController : Controller
{
    private readonly IAllRepositories<Bill> _repoBill;

    public AdminBillController(IAllRepositories<Bill> repoBill)
    {
        _repoBill = repoBill;
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

        bill.Status = newStatus;
        bill.ModifiedTime = DateTime.Now;
        await _repoBill.Update(id, bill);

        return RedirectToAction(nameof(Index));
    }
}
