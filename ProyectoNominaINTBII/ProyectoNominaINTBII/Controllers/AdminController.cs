using Microsoft.AspNetCore.Mvc;
using SistemaNomina.Models;
using Microsoft.AspNetCore.Http;  // Para gestionar sesiones
using System.Collections.Generic;  // Para listas
using System.Linq;  // Para búsqueda

namespace SistemaNomina.Controllers
{
    public class AdminController : Controller
    {
        // Simulación de base de datos con una lista de usuarios
        private static List<UserModel> users = new List<UserModel>
        {
            new UserModel
            {
                Id = 1,
                NumeroEmpleado = "001",
                Nombre = "Juan Pérez",
                RFC = "JUPR750101A0A",
                CURP = "JUPR750101HDFRRN01",
                NoIMSS = "12345678901",
                FechaInicio = new System.DateTime(2020, 01, 15),
                Puesto = "Desarrollador",
                Departamento = "IT",
                Regimen = "General",
                TipoJornada = "Diurna",
                SBC = 300.00m,
                SDI = 350.00m,
                SalarioDiario = 400.00m,
                Ejercicio = 2024,
                Folio = "ABC123456789",
                PeriodoPago = new System.DateTime(2024, 01, 15),
                FechaPago = new System.DateTime(2024, 01, 31),
                Periodicidad = "Mensual",
                DiasPagados = 30,
                Faltas = 0
            }
        };
        public IActionResult MenuPrincipal()
        {
            if (HttpContext.Session.GetString("UserRole") != "Admin")
            {
                return Unauthorized();
            }
            return View();
        }


        [HttpGet]
        public IActionResult MainMenu()
        {
            if (HttpContext.Session.GetString("UserRole") != "Admin")
            {
                return Unauthorized();  // Solo accesible por Admin
            }
            return View();
        }


        [HttpGet]
        public IActionResult AdminDashboard()
        {
            // Verificar si el usuario es Admin antes de mostrar el dashboard
            if (HttpContext.Session.GetString("UserRole") != "Admin")
            {
                return Unauthorized();  // Retorna un 403 si el rol no es Admin
            }
            return View();
        }

        // Acción para ver la lista de usuarios (Index)
        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserRole") != "Admin")
            {
                return Unauthorized();  // Solo accesible por Admin
            }
            return View(users);  // Retorna la lista de usuarios al Index
        }

        // Acción para ver la información de un usuario (GET)
        [HttpGet]
        public IActionResult ViewUserInfo(int id)
        {
            if (HttpContext.Session.GetString("UserRole") != "Admin")
            {
                return Unauthorized();  // Solo accesible por Admin
            }

            // Busca al usuario en la lista por su ID
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();  // Retorna 404 si no encuentra al usuario
            }
            return View(user);  // Retorna la vista con el modelo del usuario
        }

        // Acción para mostrar el formulario de edición de un usuario (GET)
        [HttpGet]
        public IActionResult EditUserInfo(int id)
        {
            if (HttpContext.Session.GetString("UserRole") != "Admin")
            {
                return Unauthorized();  // Solo accesible por Admin
            }

            // Busca al usuario en la lista por su ID
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();  // Retorna 404 si no encuentra al usuario
            }
            return View(user);  // Retorna la vista con el modelo del usuario
        }

        // Acción para procesar los cambios del formulario de edición (POST)
        [HttpPost]
        public IActionResult EditUserInfo(UserModel updatedUser)
        {
            if (HttpContext.Session.GetString("UserRole") != "Admin")
            {
                return Unauthorized();  // Solo accesible por Admin
            }

            // Busca al usuario en la lista por su ID
            var user = users.FirstOrDefault(u => u.Id == updatedUser.Id);
            if (user != null && ModelState.IsValid)
            {
                // Actualiza la información del usuario
                user.Nombre = updatedUser.Nombre;
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
                user.SalarioDiario = updatedUser.SalarioDiario;
                user.Ejercicio = updatedUser.Ejercicio;
                user.Folio = updatedUser.Folio;
                user.PeriodoPago = updatedUser.PeriodoPago;
                user.FechaPago = updatedUser.FechaPago;
                user.Periodicidad = updatedUser.Periodicidad;
                user.DiasPagados = updatedUser.DiasPagados;
                user.Faltas = updatedUser.Faltas;

                return RedirectToAction("ViewUserInfo", new { id = user.Id });
            }

            return View(updatedUser);  // Retorna a la vista con los datos actualizados
        }

        // Acción para crear un nuevo usuario
        [HttpGet]
        public IActionResult CreateUser()
        {
            if (HttpContext.Session.GetString("UserRole") != "Admin")
            {
                return Unauthorized();
            }
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(UserModel user)
        {
            if (HttpContext.Session.GetString("UserRole") != "Admin")
            {
                return Unauthorized();
            }

            // Simular la creación de un nuevo usuario en la lista
            user.Id = users.Count + 1;
            users.Add(user);

            return RedirectToAction("Index");  // Redirige al listado de usuarios
        }
    }
}
