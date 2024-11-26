using Microsoft.AspNetCore.Mvc;
using ProyectoNominaINTBII.ViewModels;

namespace ProyectoNominaINTBII.Controllers
{
    public class AccountController : Controller
    {

        private List<UserModel> users = new List<UserModel>
        {
            new UserModel { Username = "admin", Password = "123", Role = "Admin" },
            new UserModel { Username = "user", Password = "1234", Role = "User" }
        };

        // Acción para mostrar la vista de login (GET)
        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                // Redirigir al dashboard correspondiente según el rol
                if (HttpContext.Session.GetString("UserRole") == "Admin")
                {
                    return RedirectToAction("AdminDashboard", "Admin");
                }
                else if (HttpContext.Session.GetString("UserRole") == "User")
                {
                    return RedirectToAction("UserDashboard", "User");
                }
            }

            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Buscar el usuario en la lista temporal
            var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                // AGREGAR: Crear la sesión del usuario al autenticarse exitosamente
                HttpContext.Session.SetString("UserSession", username);
                HttpContext.Session.SetString("UserRole", user.Role);

                // Autenticación exitosa, ahora verificamos el rol
                if (user.Role == "Admin")
                {
                    return RedirectToAction("AdminDashboard", "Admin");
                }
                else if (user.Role == "User")
                {
                    return RedirectToAction("UserDashboard", "User");
                }
            }

            ViewBag.ErrorMessage = "Usuario o contraseña incorrectos";
            return View();
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }
    }
}
