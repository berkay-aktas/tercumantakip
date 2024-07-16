using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using TercumanTakipWeb.Models;
using TercumanTakipWeb.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<TercumanTakipDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("TercumanTakipConnection"));
});

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
{
    option.LoginPath = new PathString("/Users/Login");
    option.LogoutPath = new PathString("/Users/Login");
    option.AccessDeniedPath = new PathString("/Home/Index");
    option.Cookie = new()
    {
        Name = "COOKIE",
        SecurePolicy = CookieSecurePolicy.SameAsRequest,
    };

    option.SlidingExpiration = true;
    option.ExpireTimeSpan = TimeSpan.FromDays(15);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Users}/{action=Login}/{id?}");

app.Run();
