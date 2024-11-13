using Microsoft.AspNetCore.Mvc;
using ProyectoNominaINTBII.Models;
using ProyectoNominaINTBII.Services;  // Importa el servicio
using System.Collections.Generic;

namespace ProyectoNominaINTBII.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeService employeeService = new EmployeeService(); // Instancia del servicio

        // Acción para listar empleados (GET)
        public IActionResult Index()
        {
            var employees = employeeService.GetEmployees(); // Obtener empleados desde el servicio
            return View(employees);
        }

        // Acción para ver los detalles de un empleado (GET)
        public IActionResult Details(int id)
        {
            var employee = employeeService.GetEmployeeById(id);  // Usar el servicio para buscar al empleado
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // Acción para mostrar el formulario de creación de empleado (GET)
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Acción para crear un nuevo empleado (POST)
        [HttpPost]
        public IActionResult Create(EmployeeModel employee)
        {
            if (ModelState.IsValid)
            {
                employeeService.AddEmployee(employee);  // Usar el servicio para agregar el empleado
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // Acción para mostrar el formulario de edición de un empleado (GET)
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = employeeService.GetEmployeeById(id);  // Usar el servicio para obtener al empleado
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // Acción para editar un empleado (POST)
        [HttpPost]
        public IActionResult Edit(EmployeeModel updatedEmployee)
        {
            if (ModelState.IsValid)
            {
                employeeService.UpdateEmployee(updatedEmployee);  // Usar el servicio para actualizar el empleado
                return RedirectToAction("Index");
            }
            return View(updatedEmployee);
        }

        // Acción para eliminar un empleado (GET)
        public IActionResult Delete(int id)
        {
            employeeService.DeleteEmployee(id);  // Usar el servicio para eliminar al empleado
            return RedirectToAction("Index");
        }
    }
}
