using System;

namespace SistemaNomina.Models
{
    public class PayrollModel
    {
        public int Id { get; set; }                    // ID de la nómina
        public int EmployeeId { get; set; }            // ID del empleado relacionado
        public EmployeeModel Employee { get; set; }    // Relación con el empleado
        public decimal SueldoBase { get; set; }        // Sueldo base
        public decimal Aguinaldo { get; set; }         // Aguinaldo
        public decimal PrimaVacacional { get; set; }   // Prima vacacional
        public decimal OtrasPercepciones { get; set; } // Otros bonos o prestaciones
        public decimal TotalPercepciones { get; set; } // Suma de todas las percepciones
        public decimal ISR { get; set; }               // Impuesto sobre la renta (ISR)
        public decimal IMSS { get; set; }              // Deducción de IMSS
        public decimal Infonavit { get; set; }         // Deducción de Infonavit
        public decimal Fonacot { get; set; }           // Deducción de Fonacot
        public decimal OtrasDeducciones { get; set; }  // Otras deducciones
        public decimal TotalDeducciones { get; set; }  // Suma de todas las deducciones
        public decimal SalarioNeto { get; set; }       // Salario neto después de deducciones
        public DateTime FechaPago { get; set; }        // Fecha de pago
    }
}
