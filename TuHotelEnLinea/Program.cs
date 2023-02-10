using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TuHotelEnLinea;
using TuHotelEnLinea.CommandHandler;
using TuHotelEnLinea.Commands;
using TuHotelEnLinea.Configuration;
using TuHotelEnLinea.Data;
using TuHotelEnLinea.DTOs;
using TuHotelEnLinea.Models;
using TuHotelEnLinea.QueryHandler;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TuHotelEnLineaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TuHotelEnLineaContext") ?? throw new InvalidOperationException("Connection string 'TuHotelEnLineaContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICommandHandler<CustomerDTO>, AddCustomerCommandHandler>();
builder.Services.AddScoped<ICommandHandler<Customer>, UpdateCommandHandler>();
builder.Services.AddScoped<ICommandHandler<RemoveByIdCommand>, RemoveCustomerCommandHandler>();
builder.Services.AddScoped<IQueryHandler<Customer, QueryByIdCommand>, CustomerQueryHandler>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
