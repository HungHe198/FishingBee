using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data_FishingBee.ContextFile;
using Data_FishingBee.Models;
using Data_FishingBee.Repositories;
using static System.Net.Mime.MediaTypeNames;

namespace FishingBee_WebStore.Controllers.ManagerShop
{
    public class EmployeesController : Controller
    {

        private readonly IAllRepositories<Employee> _Employee;
        private readonly IAllRepositories<User> _use;
        private readonly IWebHostEnvironment _env;

        public EmployeesController(IAllRepositories<Employee> employee, IAllRepositories<User> use)
        {
            _Employee = employee;
            _use = use;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var products = _Employee.GetAllQueryable()
                .Include(p => p.User)
                .ToList();
            return View(products);
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var employee = await _Employee.GetById(id.Value);
            if (employee == null)
            {
                return NotFound();
            }


            return View(employee);
        }

        // GET: Employees/Create
        public async Task<IActionResult> Create()
        {
            ViewData["UserId"] = new SelectList(await _use.GetAll(), "Id", "Email");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee, string userName, string passWord, string email)
        {

            if (!ModelState.IsValid)
            {
                // 1. Tạo User mới
                var userId = Guid.NewGuid();
                var user = new User
                {
                    Id = userId,
                    Username = userName,
                    Password = passWord, // Lưu ý: Nên mã hóa mật khẩu trong thực tế
                    Email = email,
                    CreatedTime = DateTime.Now
                };

                await _use.Create(user); // Gọi bất đồng bộ nếu hàm Create là async

                // 2. Gán UserId cho Employee
                employee.UserId = userId;
                employee.CreatedTime = DateTime.Now;

                // 3. Tạo Employee
                await _Employee.Create(employee);

                // 4. Chuyển hướng về danh sách hoặc trang nào đó
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }


        //// GET: Employees/Edit/5
        //public async Task<IActionResult> Edit(Guid? id)
        //{
        //    if (!id.HasValue)
        //    {
        //        return NotFound();
        //    }

        //    var employee = await _Employee.GetById(id.Value);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    ViewData["UserId"] = new SelectList(await _use.GetAll(), "Id", "Name", employee.UserId);

        //    return View(employee);
        //}

        //// POST: Employees/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Guid id, [Bind("Id,UserId,CreatedBy,CreatedTime,ModifiedBy,ModifiedTime,Status,Code,Fullname,Position,Salary,HireDate,IDCardNumber")] Employee employee)
        //{
        //    if (id != employee.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            await _Employee.Update(id, employee);
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            bool exists = await _Employee.EntityExists(employee.Id);
        //            if (!exists)
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }

        //    ViewData["UserId"] = new SelectList(await _use.GetAll(), "Id", "Name", employee.UserId);

        //    return View(employee);
        //}

        //// GET: Employees/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (id == null || _context.Employees == null)
        //    {
        //        return NotFound();
        //    }

        //    var employee = await _context.Employees
        //        .Include(e => e.User)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(employee);
        //}

        //// POST: Employees/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    if (_context.Employees == null)
        //    {
        //        return Problem("Entity set 'FishingBeeDbContext.Employees'  is null.");
        //    }
        //    var employee = await _context.Employees.FindAsync(id);
        //    if (employee != null)
        //    {
        //        _context.Employees.Remove(employee);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool EmployeeExists(Guid id)
        //{
        //  return (_context.Employees?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}

