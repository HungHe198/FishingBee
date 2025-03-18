using Microsoft.EntityFrameworkCore;
using Data_FishingBee.Models;
using FishingBee_WebStore.Controllers.Account;
using Data_FishingBee.ContextFile;
using Data_FishingBee.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FishingBeeDbContext>(options => { });

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<EmailService>();
builder.Services.AddScoped<IAllRepositories<Product>,AllRepositories<Product>>();
builder.Services.AddScoped<IAllRepositories<ProductDetail>,AllRepositories<ProductDetail>>();

var entityTypes = new Type[]
{
    typeof(Admin),
    typeof(Bill),
    typeof(BillDetail),
    typeof(Cart),
    typeof(Cart_PD),
    typeof(Category),
    typeof(Coupon),
    typeof(Customer),
    typeof(CustomerActivityLog),
    typeof(CustomerSupport),
    typeof(Employee),
    typeof(ImportHistory),
    typeof(Inventory),
    typeof(Manufacturer),
    typeof(Notifications),
    typeof(Product),
    typeof(ProductDetail),
    typeof(ProductImage),
    typeof(Supplier),
    typeof(User)

};

foreach (var type in entityTypes)
{
    var repoType = typeof(IAllRepositories<>).MakeGenericType(type);
    var implType = typeof(AllRepositories<>).MakeGenericType(type);
    builder.Services.AddScoped(repoType, implType);
}

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";  // Đường dẫn khi chưa đăng nhập
        options.LogoutPath = "/Account/Logout"; // Đường dẫn khi đăng xuất
        options.AccessDeniedPath = "/Account/AccessDenied"; // Đường dẫn khi bị từ chối truy cập
    });

builder.Services.AddAuthorization();
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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "forgotpassword",
    pattern: "ForgotPassword/{action=ForgotPassword}/{id?}",
    defaults: new { controller = "ForgotPassword" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
