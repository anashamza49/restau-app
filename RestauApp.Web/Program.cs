using Microsoft.EntityFrameworkCore;
using RestauApp.Infrastructure.Data;
using RestauApp.Application.Profiles;
using RestauApp.Application.Services;
using RestauApp.Domain.Interfaces;
using RestauApp.Infrastructure.Repositories;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

// config NLog
builder.Logging.ClearProviders();
builder.Host.UseNLog();

// Add services to the container.
builder.Services.AddControllersWithViews();

// config db
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("RestauApp.Infrastructure")));

// config d'Automapper
builder.Services.AddAutoMapper(typeof(RestaurantProfile));

// config DI
builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();
builder.Services.AddScoped<IRestaurantService, RestaurantService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
