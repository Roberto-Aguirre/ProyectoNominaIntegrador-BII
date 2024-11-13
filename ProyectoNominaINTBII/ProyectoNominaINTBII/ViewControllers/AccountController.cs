using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;  // Necesario para gestionar la sesión
using ProyectoNominaINTBII.Models;
using System.Collections.Generic;
using System.Linq;

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
            // AGREGAR: Verificación si el usuario ya está autenticado
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

        // Acción para procesar el login (POST)
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

            // Si no encuentra el usuario o las credenciales son incorrectas
            ViewBag.ErrorMessage = "Usuario o contraseña incorrectos";
            return View();
        }

        // Acción para cerrar sesión
        [HttpPost]
        public IActionResult Logout()
        {
            // Limpiar la sesión al cerrar sesión
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }
    }
}
