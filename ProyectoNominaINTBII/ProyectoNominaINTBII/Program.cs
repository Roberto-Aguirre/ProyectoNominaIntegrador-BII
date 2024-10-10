var builder = WebApplication.CreateBuilder(args);

// Agregar servicios para controladores y vistas (MVC)
builder.Services.AddControllersWithViews();

// AGREGAR: Habilitar la memoria caché distribuida y la sesión
builder.Services.AddDistributedMemoryCache();  // Necesario para la sesión
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Tiempo de inactividad antes de que expire la sesión
    options.Cookie.HttpOnly = true; // Seguridad
    options.Cookie.IsEssential = true; // Necesario para el funcionamiento de la sesión
});

var app = builder.Build();

// Middleware para manejar las solicitudes HTTP, archivos estáticos y routing
app.UseHttpsRedirection();   // Redirigir automáticamente a HTTPS
app.UseStaticFiles();        // Habilitar archivos estáticos (como el CSS)
app.UseRouting();            // Habilitar el sistema de rutas

// AGREGAR: Habilitar el middleware de sesión
app.UseSession();

app.UseAuthorization();      // Habilitar autorización (si lo necesitas más adelante)

// Definir las rutas para la aplicación
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");  // Redirige a la vista de login como ruta predeterminada

// Iniciar la aplicación
app.Run();
