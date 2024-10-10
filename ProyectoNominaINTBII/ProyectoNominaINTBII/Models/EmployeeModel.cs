using System;

namespace SistemaNomina.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }                 // ID único del empleado
        public string Nombre { get; set; }          // Nombre completo del empleado
        public string CURP { get; set; }            // CURP
        public string RFC { get; set; }             // RFC
        public string NSS { get; set; }             // Número de Seguro Social
        public DateTime FechaIngreso { get; set; }  // Fecha de ingreso a la empresa
        public decimal SalarioDiario { get; set; }  // Salario diario del empleado
        public decimal SalarioDiarioIntegrado { get; set; } // Salario Diario Integrado (SDI)
        public string Departamento { get; set; }    // Departamento donde trabaja
        public string Puesto { get; set; }          // Puesto o cargo del empleado
        public int DiasVacaciones { get; set; }     // Días de vacaciones según antigüedad
        public decimal PrimaVacacional { get; set; }  // Prima vacacional (25% de vacaciones)
        public decimal Aguinaldo { get; set; }      // Aguinaldo anual o proporcional
        public bool TieneInfonavit { get; set; }    // Indica si tiene crédito Infonavit
        public decimal DescuentoInfonavit { get; set; }  // Monto de descuento Infonavit
        public bool TieneFonacot { get; set; }      // Indica si tiene crédito Fonacot
        public decimal DescuentoFonacot { get; set; }  // Monto de descuento Fonacot
        public decimal OtrasDeducciones { get; set; } // Otras deducciones (préstamos, pensiones, etc.)
    }
}
