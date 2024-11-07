namespace ProyectoNominaINTBII.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }           // ID del empleado
        public string Nombre { get; set; }    // Nombre completo del empleado
        public string CURP { get; set; }      // CURP del empleado
        public string RFC { get; set; }       // RFC del empleado
        public string Puesto { get; set; }    // Puesto del empleado
        public string Departamento { get; set; } // Departamento del empleado
        public decimal SalarioDiario { get; set; } // Salario diario del empleado
        public decimal SalarioDiarioIntegrado { get; set; } // Salario diario integrado (SDI)
        public DateTime FechaIngreso { get; set; }  // Fecha de ingreso del empleado
        public string NSS { get; set; }       // Número de seguridad social (NSS)

        // Otros campos para deducciones y prestaciones
        public decimal Aguinaldo { get; set; }
        public decimal PrimaVacacional { get; set; }
        public int DiasVacaciones { get; set; }
        public bool TieneInfonavit { get; set; }
        public decimal DescuentoInfonavit { get; set; }
        public bool TieneFonacot { get; set; }
        public decimal DescuentoFonacot { get; set; }
        public decimal OtrasDeducciones { get; set; }
    }
}
