using Microsoft.AspNetCore.Mvc;
using ProyectoNominaINTBII.Models;
using Microsoft.AspNetCore.Http;  // Para gestionar sesiones
using System.Collections.Generic;  // Para listas
using System.Linq;  // Para búsqueda
using Microsoft.AspNetCore.Mvc.Rendering;


namespace ProyectoNominaINTBII.Controllers
{
    public class AdminController : Controller
    {
        private static List<UserModel> users = new List<UserModel>();

        [HttpGet]
        public IActionResult AdminDashboard()
        {
            if (HttpContext.Session.GetString("UserSession") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        [HttpGet]
        public IActionResult ListUsers()
        {
            return View(users); // Envía la lista de usuarios a la vista ListUsers.cshtml
        }

        [HttpGet]
        public IActionResult ViewUserInfo(int id)
        {
            if (HttpContext.Session.GetString("UserRole") != "Admin")
            {
                return Unauthorized();
            }

            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            var userModel = new UserModel(); // Inicializamos el modelo
            return View(userModel); // Pasamos el modelo a la vista
        }

      [HttpPost]
        [HttpPost]
        public IActionResult CreateUser(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                // Asigna un nuevo ID y agrega el usuario a la lista simulada
                userModel.Id = users.Count + 1;
                users.Add(userModel);

                // Guarda el mensaje de éxito en TempData
                TempData["SuccessMessage"] = "Usuario creado con éxito.";

                return RedirectToAction("ListUsers");
            }

            return View(userModel);
        }



        [HttpPost]
        public IActionResult DeleteUser(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                users.Remove(user);
                return Ok();
            }
            return NotFound();
        }


        [HttpGet]
        public IActionResult EditUserInfo(int id)
        {
            if (HttpContext.Session.GetString("UserRole") != "Admin")
            {
                return Unauthorized();
            }

            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        public IActionResult EditAllUsersInfo(int id)
        {
            // Asegúrate de obtener el usuario correctamente
            var usuario = users.FirstOrDefault(u => u.Id == id);

            if (usuario == null)
            {
                return NotFound();
            }

            // Configura ViewBag.EstadoOptions como lista de SelectListItem
            ViewBag.EstadoOptions = new List<SelectListItem>
    {
        new SelectListItem { Value = "true", Text = "Activo", Selected = usuario.IsActive },
        new SelectListItem { Value = "false", Text = "Inactivo", Selected = !usuario.IsActive }
    };

            return View(usuario);
        }





        [HttpGet]
        public IActionResult CompanyInfo()
        {
            CompanyInfoModel companyInfo = new CompanyInfoModel
            {
                Nombre = "Empresa Ejemplo S.A.",
                Direccion = "Av. Ejemplo 123",
                RFC = "AAA010101AAA",
                Telefono = "555-1234",
                Email = "contacto@empresa.com"
            };

            return View(companyInfo);
        }

        [HttpPost]
        public IActionResult EditAllUsersInfo(UserModel updatedUser)
        {
            if (!ModelState.IsValid)
            {
                // Si hay errores de validación, devuelve el modelo a la vista para mostrar mensajes de error
                ViewBag.EstadoOptions = new List<SelectListItem>
        {
            new SelectListItem { Value = "true", Text = "Activo", Selected = updatedUser.IsActive },
            new SelectListItem { Value = "false", Text = "Inactivo", Selected = !updatedUser.IsActive }
        };
                return View(updatedUser);
            }

            // Buscar el usuario en la lista existente
            var user = users.FirstOrDefault(u => u.Id == updatedUser.Id);
            if (user != null)
            {
                // Actualizar los datos del usuario con los valores del modelo actualizado
                user.Nombre = updatedUser.Nombre;
                user.NumeroEmpleado = updatedUser.NumeroEmpleado;
                user.RFC = updatedUser.RFC;
                user.CURP = updatedUser.CURP;
                user.NoIMSS = updatedUser.NoIMSS;
                user.FechaInicio = updatedUser.FechaInicio;
                user.Puesto = updatedUser.Puesto;
                user.Departamento = updatedUser.Departamento;
                user.Regimen = updatedUser.Regimen;
                user.TipoJornada = updatedUser.TipoJornada;
                user.SBC = updatedUser.SBC;
                user.SDI = updatedUser.SDI;
                user.Ejercicio = updatedUser.Ejercicio;
                user.Folio = updatedUser.Folio;
                user.PeriodoPago = updatedUser.PeriodoPago;
                user.FechaPago = updatedUser.FechaPago;
                user.Periodicidad = updatedUser.Periodicidad;
                user.DiasPagados = updatedUser.DiasPagados;
                user.Faltas = updatedUser.Faltas;
                user.Telefono = updatedUser.Telefono;
                user.Email = updatedUser.Email;
                user.IsActive = updatedUser.IsActive;
                user.Role = updatedUser.Role;

                // Redirigir a la lista de usuarios después de actualizar
                return RedirectToAction("ListUsers");
            }

            // Si el usuario no se encuentra, retorna un error 404
            return NotFound();
        }


        [HttpPost]
        public IActionResult ToggleUserStatus(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                // Cambia el estado del usuario y guarda el cambio en la lista
                user.IsActive = !user.IsActive;
                return Ok();
            }
            return NotFound();
        }

    }
}
