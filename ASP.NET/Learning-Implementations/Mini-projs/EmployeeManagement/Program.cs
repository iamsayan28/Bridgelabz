using System;
using EmployeeManagement.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// MVC services
builder.Services.AddControllersWithViews();

// Session is the ASP.NET Core replacement for classic Session (still exists),
// but must be explicitly registered and enabled via middleware.
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// ADO.NET repositories, registered for dependency injection
builder.Services.AddScoped<EmployeeRepository>();
builder.Services.AddScoped<UserRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Account/Login");
}

app.UseStaticFiles();
app.UseRouting();

// Session middleware must be added before routes/controllers that use it
app.UseSession();

// Custom route (in addition to the default route below), e.g.:
// /emp/101/details  ->  EmployeeController.Details(101)
app.MapControllerRoute(
    name: "employeeShortDetails",
    pattern: "emp/{id:int}/details",
    defaults: new { controller = "Employee", action = "Details" });

// Default MVC route. Start page is the Login screen.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
