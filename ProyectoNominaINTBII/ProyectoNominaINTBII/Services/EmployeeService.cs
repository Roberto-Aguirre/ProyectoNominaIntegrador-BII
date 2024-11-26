using ProyectoNominaINTBII.Models;

namespace ProyectoNominaINTBII.Services
{
    public class EmployeeService
    {
        // Lista temporal de empleados
        private static List<EmployeeModel> employees = new List<EmployeeModel>
        {
            new EmployeeModel { Id = 1, Nombre = "Juan Pérez", CURP = "JUAP810101HDFRRL01", RFC = "JUAP810101ABC", NSS = "12345678901", FechaIngreso = new System.DateTime(2015, 01, 01), SalarioDiario = 300, SalarioDiarioIntegrado = 350, Departamento = "IT", Puesto = "Desarrollador", DiasVacaciones = 12, PrimaVacacional = 900, Aguinaldo = 4500, TieneInfonavit = true, DescuentoInfonavit = 500, TieneFonacot = false, OtrasDeducciones = 300 }
        };

        // Método para obtener la lista de empleados
        public List<EmployeeModel> GetEmployees()
        {
            return employees;
        }

        // Método para obtener un empleado por su ID
        public EmployeeModel GetEmployeeById(int id)
        {
            return employees.FirstOrDefault(e => e.Id == id);
        }

        // Método para agregar un nuevo empleado
        public void AddEmployee(EmployeeModel employee)
        {
            employee.Id = employees.Count + 1;  // Asignar un nuevo ID
            employees.Add(employee);
        }

        // Método para actualizar un empleado existente
        public void UpdateEmployee(EmployeeModel updatedEmployee)
        {
            var employee = GetEmployeeById(updatedEmployee.Id);
            if (employee != null)
            {
                employee.Nombre = updatedEmployee.Nombre;
                employee.CURP = updatedEmployee.CURP;
                employee.RFC = updatedEmployee.RFC;
                employee.NSS = updatedEmployee.NSS;
                employee.FechaIngreso = updatedEmployee.FechaIngreso;
                employee.SalarioDiario = updatedEmployee.SalarioDiario;
                employee.SalarioDiarioIntegrado = updatedEmployee.SalarioDiarioIntegrado;
                employee.Departamento = updatedEmployee.Departamento;
                employee.Puesto = updatedEmployee.Puesto;
                employee.DiasVacaciones = updatedEmployee.DiasVacaciones;
                employee.PrimaVacacional = updatedEmployee.PrimaVacacional;
                employee.Aguinaldo = updatedEmployee.Aguinaldo;
                employee.TieneInfonavit = updatedEmployee.TieneInfonavit;
                employee.DescuentoInfonavit = updatedEmployee.DescuentoInfonavit;
                employee.TieneFonacot = updatedEmployee.TieneFonacot;
                employee.DescuentoFonacot = updatedEmployee.DescuentoFonacot;
                employee.OtrasDeducciones = updatedEmployee.OtrasDeducciones;
            }
        }

        // Método para eliminar un empleado
        public void DeleteEmployee(int id)
        {
            var employee = GetEmployeeById(id);
            if (employee != null)
            {
                employees.Remove(employee);
            }
        }
    }
}
