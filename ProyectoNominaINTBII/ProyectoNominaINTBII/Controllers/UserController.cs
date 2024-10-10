using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;  // Para gestionar sesiones
using SistemaNomina.Models;
using System.Linq;

namespace SistemaNomina.Controllers
{
    public class UserController : Controller
    {
        // Lista simulada de usuarios (en la práctica, esto vendría de una base de datos)
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
                FechaInicio = new DateTime(2020, 01, 15),
                Puesto = "Desarrollador",
                Departamento = "IT",
                Regimen = "General",
                TipoJornada = "Diurna",
                SBC = 300.00m,
                SDI = 350.00m,
                SalarioDiario = 400.00m,
                Ejercicio = 2024,
                Folio = "ABC123456789",
                PeriodoPago = new DateTime(2024, 01, 15),
                FechaPago = new DateTime(2024, 01, 31),
                Periodicidad = "Mensual",
                DiasPagados = 30,
                Faltas = 0
            }
        };

        [HttpGet]
        public IActionResult UserDashboard()
        {
            // Verificar que el usuario esté autenticado como User
            if (HttpContext.Session.GetString("UserRole") != "User")
            {
                return Unauthorized();
            }
            return View();
        }

        // Funcionalidad para que el usuario vea su nómina
        public IActionResult ViewPayroll()
        {
            if (HttpContext.Session.GetString("UserRole") != "User")
            {
                return Unauthorized();
            }

            // Lógica para mostrar nómina
            return View();
        }

        // Acción para ver la información del usuario
        [HttpGet]
        public IActionResult ViewUserInfo(int id)
        {
            // Busca al usuario en la lista por su ID
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user); // Retorna la vista con el modelo del usuario
        }

        // Acción para mostrar el formulario de edición de información del usuario (GET)
        [HttpGet]
        public IActionResult EditUserInfo(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user); // Mostrar formulario para editar la información
        }

        // Acción para procesar los cambios del formulario de edición (POST)
        [HttpPost]
        public IActionResult EditUserInfo(UserModel updatedUser)
        {
            var user = users.FirstOrDefault(u => u.Id == updatedUser.Id);
            if (user != null && ModelState.IsValid)
            {
                // Actualizar la información del usuario
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
            return View(updatedUser); // Volver a mostrar la vista con los datos modificados
        }
    }
}
