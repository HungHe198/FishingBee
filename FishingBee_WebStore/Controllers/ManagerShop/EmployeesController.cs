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
        // tạo tài khoản cho đăng nhập cùng với với đó là lưu các thông tin cá nhân sang bảng employee
        public async Task<IActionResult> Create()
        {
           
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee, string userName, string passWord, string email)
        {
            //try
            //{
            //    if (ModelState.IsValid)
            //    {
            //        // 1. Tạo User mới
            //        var userId = Guid.NewGuid();
            //        var user = new User
            //        {
            //            Id = userId,
            //            Username = userName,
            //            Password = passWord, // Ghi chú: Cần mã hóa khi triển khai thật
            //            Email = email,
            //            UserType = "Employee",
            //            CreatedTime = DateTime.Now,
            //            Status = "1"
            //        };

            //        await _use.Create(user);

            //        // 2. Gán UserId cho Employee
            //        employee.UserId = userId;
            //        employee.CreatedTime = DateTime.Now;
            //        employee.Status = "1";

            //        // 3. Tạo Employee
            //        await _Employee.Create(employee);

            //        // 4. Thông báo thành công
            //        TempData["SuccessMessage"] = "Tạo nhân viên thành công!";
            //        return RedirectToAction(nameof(Index));
            //    }

            //    TempData["ErrorMessage"] = "Dữ liệu không hợp lệ.";
            //    return View(employee);
            //}
            //catch (Exception ex)
            //{
            //    // Đường dẫn thư mục log trong wwwroot/logs
            //    var logFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "logs");
            //    if (!Directory.Exists(logFolder))
            //    {
            //        Directory.CreateDirectory(logFolder);
            //    }

            //    var logFile = Path.Combine(logFolder, "log.txt");
            //    var logMessage = $"[{DateTime.Now}] Lỗi tạo nhân viên: {ex.Message}\n{ex.StackTrace}\n";

            //    await System.IO.File.AppendAllTextAsync(logFile, logMessage);

            //    TempData["ErrorMessage"] = "Có lỗi xảy ra trong quá trình tạo nhân viên. Vui lòng thử lại.";
            //    return View(employee);
            //}
            //finally
            //{
            //    // Đây có thể mở rộng ra thông báo cho cả lỗi hoặc thành công nếu cần
            //    // Hiện tại đã dùng TempData ở trên, nên không cần thêm ở đây
            //}
            try
            {
                if (ModelState.IsValid)
                {
                    // 1. Generate new User ID and check for uniqueness
                    var userId = Guid.NewGuid();
                    if (await _use.EntityExists(userId))
                    {
                        TempData["ErrorMessage"] = "ID đã tồn tại";
                        return View(employee);
                    }

                    // 2. Create new User
                    var user = new User
                    {
                        Id = userId,
                        Username = userName,
                        Password = passWord, // Note: Should be hashed in production
                        Email = email,
                        UserType = "Employee",
                        CreatedTime = DateTime.Now,
                        Status = "1"
                    };

                    await _use.Create(user);

                    // 3. Check if Employee ID already exists
                    if (await _Employee.EntityExists(employee.Id))
                    {
                        TempData["ErrorMessage"] = "mã ID không được trùng ";
                        return View(employee);
                    }

                    // 4. Check if Employee Code already exists
                    var employees = await _Employee.GetAll();
                    if (employees.Any(e => e.Code == employee.Code))
                    {
                        TempData["ErrorMessage"] = "mã định danh đã tồn tại ";
                        return View(employee);
                    }

                    // 5. Assign UserId to Employee and set properties
                    employee.UserId = userId;
                    employee.CreatedTime = DateTime.Now;
                    employee.Status = "1";

                    // 6. Create Employee
                    await _Employee.Create(employee);

                    // 7. Success notification
                    TempData["SuccessMessage"] = "Nhân viên đã được tạo thành công!";
                    return RedirectToAction(nameof(Index));
                }

                TempData["ErrorMessage"] = "Dữ liệu không hợp lệ.";
                return View(employee);
            }
            catch (Exception ex)
            {
                // Log error to file
                var logFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "logs");
                if (!Directory.Exists(logFolder))
                {
                    Directory.CreateDirectory(logFolder);
                }

                var logFile = Path.Combine(logFolder, "log.txt");
                var logMessage = $"[{DateTime.Now}] Error creating employee: {ex.Message}\n{ex.StackTrace}\n";

                await System.IO.File.AppendAllTextAsync(logFile, logMessage);

                TempData["ErrorMessage"] = "Đã xảy ra lỗi trong quá trình tạo nhân viên. Vui lòng thử lại.";
                return View(employee);
            }
            finally
            {
                // Can be extended for additional notifications if needed
            }
        }


        public async Task<IActionResult> Edit(Guid id)
        {
            var employee = await _Employee.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }

            // Lấy thêm thông tin User
            var user = await _use.GetById(employee.UserId);
            ViewBag.User = user;

            return View(employee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Employee employee, Guid UserId, string Username, string Password, string Email)
        {
            if (id != employee.Id)
                return NotFound();

            try
            {
                if (ModelState.IsValid)
                {
                    // Cập nhật User
                    var user = await _use.GetById(UserId);
                    if (user != null)
                    {
                        user.Username = Username;
                        user.Password = Password; // Gợi ý: nên mã hóa
                        user.Email = Email;
                        user.ModifiedTime = DateTime.Now;

                        await _use.Update(user.Id,user);
                    }

                    // Cập nhật Employee
                    employee.ModifiedTime = DateTime.Now;
                    await _Employee.Update(employee.Id,employee);

                    TempData["SuccessMessage"] = "Cập nhật nhân viên và tài khoản thành công!";
                    return RedirectToAction(nameof(Index));
                }

                TempData["ErrorMessage"] = "Dữ liệu không hợp lệ.";
                return View(employee);
            }
            catch (Exception ex)
            {
                await LogError("Edit Employee + User", ex);
                TempData["ErrorMessage"] = "Lỗi khi cập nhật thông tin.";
                return View(employee);
            }

        }
        private async Task LogError(string action, Exception ex)
        {
            var logFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "logs");
            if (!Directory.Exists(logFolder))
                Directory.CreateDirectory(logFolder);

            var logFile = Path.Combine(logFolder, "log.txt");
            var logMessage = $"[{DateTime.Now}] {action} - {ex.Message}\n{ex.StackTrace}\n";

            await System.IO.File.AppendAllTextAsync(logFile, logMessage);
        }



    }
}

