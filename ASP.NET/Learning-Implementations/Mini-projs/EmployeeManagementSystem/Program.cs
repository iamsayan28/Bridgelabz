using EmployeeManagementSystem.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Add DbContext with MySQL provider
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// 2. Register Repository
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

builder.Services.AddControllersWithViews();