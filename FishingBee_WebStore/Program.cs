using Microsoft.EntityFrameworkCore;
using Data_FishingBee.Models;
using FishingBee_WebStore.Controllers.Account;
using Data_FishingBee.ContextFile;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FishingBeeDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<EmailService>();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "forgotpassword",
    pattern: "ForgotPassword/{action=ForgotPassword}/{id?}",
    defaults: new { controller = "ForgotPassword" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
