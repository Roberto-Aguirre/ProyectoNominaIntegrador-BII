using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProyectoNominaINTBII.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache();

builder.Services.AddDbContext<ProyDb2bContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProyDb2bContext") ?? throw new InvalidOperationException("Connection string 'ProyDb2bContext' not found.")));

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Tiempo de inactividad antes de que expire la sesi�n
    options.Cookie.HttpOnly = true; // Seguridad
    options.Cookie.IsEssential = true; // Necesario para el funcionamiento de la sesi�n
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();