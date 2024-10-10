var builder = WebApplication.CreateBuilder(args);

// Agregar servicios para controladores y vistas (MVC)
builder.Services.AddControllersWithViews();

// AGREGAR: Habilitar la memoria cach� distribuida y la sesi�n
builder.Services.AddDistributedMemoryCache();  // Necesario para la sesi�n
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Tiempo de inactividad antes de que expire la sesi�n
    options.Cookie.HttpOnly = true; // Seguridad
    options.Cookie.IsEssential = true; // Necesario para el funcionamiento de la sesi�n
});

var app = builder.Build();

// Middleware para manejar las solicitudes HTTP, archivos est�ticos y routing
app.UseHttpsRedirection();   // Redirigir autom�ticamente a HTTPS
app.UseStaticFiles();        // Habilitar archivos est�ticos (como el CSS)
app.UseRouting();            // Habilitar el sistema de rutas

// AGREGAR: Habilitar el middleware de sesi�n
app.UseSession();

app.UseAuthorization();      // Habilitar autorizaci�n (si lo necesitas m�s adelante)

// Definir las rutas para la aplicaci�n
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");  // Redirige a la vista de login como ruta predeterminada

// Iniciar la aplicaci�n
app.Run();
