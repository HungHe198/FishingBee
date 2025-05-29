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
    [Authorize(Roles = "Admin")]  
    public class UserController : Controller
    {
        private readonly FishingBeeDbContext _context;

        public UserController(FishingBeeDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _context.Users.OrderByDescending(x=>x.CreatedTime).ToListAsync();
            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ToggleStatus(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return Json(new { success = false, message = "Người dùng không tồn tại!" });
            }
            user.Status = user.Status == "Active" ? "Inactive" : "Active";

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return Json(new { success = true, newStatus = user.Status });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    {
                        user.Id = Guid.NewGuid();
                        user.CreatedTime = DateTime.Now;
                        user.Status = "Active";

                        _context.Users.Add(user);
                        await _context.SaveChangesAsync(); 
                        if (user.UserType == "Employee")
                        {
                            var employee = new Employee
                            {
                                Id = Guid.NewGuid(),
                                UserId = user.Id,
                                CreatedTime = DateTime.Now,
                                Status = "Active",
                                Code = "EMP" + new Random().Next(1000, 9999),
                                Fullname = user.Username,
                                Position = "Nhân viên",
                                Salary = 0,
                                HireDate = DateTime.Now
                            };

                            _context.Employees.Add(employee);
                            await _context.SaveChangesAsync();
                        }
                        else if (user.UserType == "Admin")
                        {
                            var admin = new Admin
                            {
                                Id = Guid.NewGuid(),
                                UserId = user.Id,
                                CreatedTime = DateTime.Now,
                                Status = "Active",
                                UserType = "Admin",
                            };

                            _context.Admins.Add(admin);
                            await _context.SaveChangesAsync();
                        }
                        await transaction.CommitAsync();
                        return RedirectToAction(nameof(Index));
                    }

                }
            }

            return View(user);
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound();

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, User user)
        {
            if (id != user.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound();

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Người dùng đã được xóa!";
            }
            else
            {
                TempData["ErrorMessage"] = "Người dùng không tồn tại!";
            }

            return RedirectToAction(nameof(Index)); 
        }
        public async Task<IActionResult> Details(Guid id)
        {
            var userDetails = await _context.Users
                .Include(u => u.Admin) 
                .Include(u => u.Customer)
                .Include(u => u.Employee)
                .Where(u => u.Id == id)
                .Select(u => new
                {
                    u.Id,
                    u.Username,
                    u.Email,
                    u.PhoneNumber,
                    u.Status,
                    u.CreatedTime,
                    u.UserType,

                    FullName = u.Admin != null ? u.Admin.FullName :
                               u.Customer != null ? u.Customer.FullName :
                               u.Employee != null ? u.Employee.Fullname : null,

                    CustomerId = u.Customer != null ? u.Customer.Id : (Guid?)null,
                    Address = u.Customer != null ? u.Customer.Address : null,
                    IDCardNumber = u.Customer != null ? u.Customer.IDCardNumber : null,
                    DoB = u.Customer != null ? u.Customer.DoB : null,
                    LoyaltyPoints = u.Customer != null ? u.Customer.LoyaltyPoints : (int?)null,

                    EmployeeId = u.Employee != null ? u.Employee.Id : (Guid?)null,
                    EmployeeFullName = u.Employee != null ? u.Employee.Fullname : null,
                    Position = u.Employee != null ? u.Employee.Position : null,
                    Salary = u.Employee != null ? u.Employee.Salary : (decimal?)null,
                    HireDate = u.Employee != null ? u.Employee.HireDate : null,
                    EmployeeCode = u.Employee != null ? u.Employee.Code : null,
                    EmployeeIDCardNumber = u.Employee != null ? u.Employee.IDCardNumber : null,
                    AdminId = u.Admin != null ? u.Admin.Id : (Guid?)null,
                    AdminUserType = u.Admin != null ? u.Admin.UserType : null,
                })
                .FirstOrDefaultAsync();

            if (userDetails == null)
            {
                return NotFound();
            }
            if (userDetails.UserType == "Customer" && userDetails.CustomerId != null)
            {
                return View("CustomerDetails", userDetails);
            }
            else if (userDetails.UserType == "Employee" && userDetails.EmployeeId != null)
            {
                return View("DetailEmployee", userDetails);
            }
            else if (userDetails.UserType == "Admin" && userDetails.AdminId != null)
            {
                return View("DetailAdmin", userDetails);
            }

            return View(userDetails);
        }


        public async Task<IActionResult> EditEmployee(Guid id)
        {
            var employee = await _context.Employees
                .Include(e => e.User)
                .Where(e => e.UserId == id)
                .Select(e => new
                {
                    e.Id,
                    e.Code,
                    e.Fullname,
                    e.Position,
                    e.Salary,
                    e.HireDate,
                    e.IDCardNumber,
                    Email = e.User.Email,
                    PhoneNumber = e.User.PhoneNumber,
                    e.Status
                })
                .FirstOrDefaultAsync();

            if (employee == null)
            {
                return NotFound();
            }

            return View("EditEmployee", employee);
        }
        [HttpPost]
        public async Task<IActionResult> EditEmployee(Guid id, string fullname, string position, decimal salary, DateTime? hireDate, string idCardNumber, string email, string phoneNumber, string status)
        {
            var employee = await _context.Employees
                .Include(e => e.User)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (employee == null)
            {
                return NotFound();
            }
            employee.Fullname = fullname;
            employee.Position = position;
            employee.Salary = salary;
            employee.HireDate = hireDate;
            employee.IDCardNumber = idCardNumber;
            employee.ModifiedTime = DateTime.Now;
            if (employee.User != null)
            {
                employee.User.Email = email;
                employee.User.PhoneNumber = phoneNumber;
                employee.User.ModifiedTime = DateTime.Now;
            }

            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Cập nhật nhân viên thành công!";
            return RedirectToAction("Details", new { id = employee.UserId });
        }
        public async Task<IActionResult> EditAdmin(Guid id)
        {
            var user = await _context.Users
                .Include(u => u.Admin)
                .FirstOrDefaultAsync(u => u.Admin.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> EditAdmin(Guid Id, string Username, string Email, string PhoneNumber, string? FullName)
        {
            var admin = await _context.Admins.FirstOrDefaultAsync(a => a.Id == Id);

            if (admin == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == admin.UserId);

            if (user == null)
            {
                return NotFound();
            }
            user.Username = Username;
            user.Email = Email;
            user.PhoneNumber = PhoneNumber;
            admin.FullName = FullName;

            _context.Users.Update(user);
            _context.Admins.Update(admin);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "User", new { id = user.Id });
        }
    


    }
}
