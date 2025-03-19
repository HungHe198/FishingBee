using Microsoft.AspNetCore.Mvc;
using Data_FishingBee.ContextFile;
using Data_FishingBee.Models;
using System.Linq;

public class CustomerController : Controller
{
    private readonly FishingBeeDbContext _context;

    public CustomerController(FishingBeeDbContext context)
    {
        _context = context;
    }

    public IActionResult CompleteProfile(Guid userId)
    {
        var customer = _context.Customers.FirstOrDefault(c => c.UserId == userId);
        if (customer == null)
        {
            return NotFound();
        }

        return View(customer);
    }

    [HttpPost]
    public IActionResult CompleteProfile(Customer model)
    {
        var customer = _context.Customers.FirstOrDefault(c => c.Id == model.Id);
        if (customer == null)
        {
            return NotFound();
        }

        customer.FullName = model.FullName;
        customer.IDCardNumber = model.IDCardNumber;
        customer.Address = model.Address;
        customer.ModifiedTime = DateTime.Now;

        _context.SaveChanges();
        TempData["SuccessMessage"] = "Cập nhật thông tin thành công!";
        return RedirectToAction("Index", "Home");
    }
}
