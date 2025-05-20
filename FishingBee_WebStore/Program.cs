using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Data_FishingBee.Models;
using FishingBee_WebStore.Controllers.Account;
using Data_FishingBee.ContextFile;
using Data_FishingBee.Repositories;
using Microsoft.AspNetCore.Http.Features;

var builder = WebApplication.CreateBuilder(args);

// Cấu hình DbContext
builder.Services.AddDbContext<FishingBeeDbContext>(options => { });

builder.Services.AddControllersWithViews();

// Cấu hình Authentication với Cookie
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
    });
builder.Services.AddSession();
builder.Services.AddScoped<EmailService>();
builder.Services.AddScoped(typeof(IAllRepositories<>), typeof(AllRepositories<>));
builder.Services.AddScoped<ICartRepository, CartRepository>();
//builder.Services.AddScoped<IAllRepositories<ProductDetail>, AllRepositories<ProductDetail>>();
//var entityTypes = new Type[]
//{
//    typeof(Admin),
//    typeof(Bill),
//    typeof(BillDetail),
//    typeof(Cart),
//    typeof(Cart_PD),
//    typeof(Category),
//    typeof(Coupon),
//    typeof(Customer),
//    typeof(CustomerActivityLog),
//    typeof(CustomerSupport),
//    typeof(Employee),
//    typeof(ImportHistory),
//    typeof(Inventory),
//    typeof(Manufacturer),
//    typeof(Notifications),
//    typeof(Product),
//    typeof(ProductDetail),
//    typeof(ProductImage),
//    typeof(Supplier),
//    typeof(User)

//};

//foreach (var type in entityTypes)
//{
//    var repoType = typeof(IAllRepositories<>).MakeGenericType(type);
//    var implType = typeof(AllRepositories<>).MakeGenericType(type);
//    builder.Services.AddScoped(repoType, implType);
//}
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddHttpContextAccessor();
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 1024L * 1024 * 1024; // 1GB
});

builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.MaxRequestBodySize = 1024L * 1024 * 1024; // 1GB
});

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
    name: "search",
    pattern: "search",
    defaults: new { controller = "ProductDetails", action = "Search" });

app.MapControllerRoute(
    name: "forgotpassword",
    pattern: "ForgotPassword/{action=ForgotPassword}/{id?}",
    defaults: new { controller = "ForgotPassword" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Products}/{action=Index}/{id?}");

app.Run();
