using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProyectoNominaINTBII.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Prueba3Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Prueba3Context") ?? throw new InvalidOperationException("Connection string 'Prueba3Context' not found.")));

builder.Services.AddAutoMapper(typeof(Program));

// Add services to the container.
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();