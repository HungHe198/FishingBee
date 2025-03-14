using Data_FishingBee.ContextFile;
using Data_FishingBee.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

namespace FishingBee_WebStore.Controllers.Account
{
    public class ForgotPasswordController : Controller
    {
        private readonly FishingBeeDbContext _context;
        private readonly IConfiguration _configuration;

        public ForgotPasswordController(FishingBeeDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(string email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            if (user == null)
            {
                ViewBag.ErrorMessage = "Email không tồn tại trong hệ thống.";
                return View();
            }

            // Tạo mật khẩu mới
            string newPassword = GenerateRandomPassword();
            user.Password = HashPassword(newPassword); // Băm mật khẩu trước khi lưu vào DB
            _context.SaveChanges();

            // Gửi email chứa mật khẩu mới
            bool isSent = SendEmail(user.Email, newPassword);
            if (!isSent)
            {
                ViewBag.ErrorMessage = "Có lỗi khi gửi email. Vui lòng thử lại.";
                return View();
            }

            TempData["SuccessMessage"] = "Mật khẩu mới đã được gửi đến email của bạn. Hãy kiểm tra hộp thư và đổi mật khẩu ngay!";
            return RedirectToAction("Login", "Account");
        }

        private bool SendEmail(string toEmail, string newPassword)
        {
                // Lấy thông tin SMTP từ appsettings.json
                string smtpServer = _configuration["EmailSettings:SmtpServer"];
                int port = int.Parse(_configuration["EmailSettings:Port"]);
                string senderEmail = _configuration["EmailSettings:SenderEmail"];
                string senderPassword = _configuration["EmailSettings:SenderPassword"];
                string senderName = _configuration["EmailSettings:SenderName"];

                string subject = "Khôi phục mật khẩu - FishingBee WebStore";
                string body = $@"
                    <p>Xin chào,</p>
                    <p>Bạn đã yêu cầu đặt lại mật khẩu.</p>
                    <p>Mật khẩu mới của bạn là: <b>{newPassword}</b></p>
                    <p><b>Vui lòng đăng nhập và đổi mật khẩu ngay để bảo vệ tài khoản.</b></p>
                    <p>Trân trọng,<br>{senderName}</p>";

                var smtpClient = new SmtpClient(smtpServer)
                {
                    Port = port,
                    Credentials = new NetworkCredential(senderEmail, senderPassword),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(senderEmail, senderName),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true,
                };
                mailMessage.To.Add(toEmail);

                smtpClient.Send(mailMessage);
                return true;
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }

        private string GenerateRandomPassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789@#$!";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
