using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoNominaINTBII.Models
{
    public class PayrollModel
    {

        public int Id { get; set; } // Nueva propiedad Id para identificar cada nómina

        // Información de la Empresa
        public string NombreEmpresa { get; set; }
        public string RFC_Empresa { get; set; }
        public string DireccionEmpresa { get; set; }
        public string LugarExpedicion { get; set; }
        public string RegistroPatronal { get; set; }

        // Información del Empleado
        public string NumeroEmpleado { get; set; }
        public string Empleado { get; set; }
        public string RFCEmpleado { get; set; }
        public string CURP { get; set; }
        public string NumeroIMSS { get; set; }
        public DateTime? FechaInicioRelacion { get; set; }
        public string Puesto { get; set; }
        public string Departamento { get; set; }
        public string RegimenFiscal { get; set; }
        public string TipoDeJornada { get; set; }
        public string TipoDeContrato { get; set; }
        public string PeriodoPago { get; set; }
        public DateTime? FechaPago { get; set; }
        public int DiasLaborados { get; set; }
        public int DiasPagados { get; set; }
        public double SalarioDiario { get; set; }
        public double SBC { get; set; }
        public double SDI { get; set; }

        // Percepciones y Deducciones
        public List<Percepcion> Percepciones { get; set; } = new List<Percepcion>();
        public List<Deduccion> Deducciones { get; set; } = new List<Deduccion>();

        // Cálculos
        public double TotalPercepciones => Percepciones.Sum(p => p.Importe);
        public double TotalDeducciones => Deducciones.Sum(d => d.Importe);
        public double TotalNeto => TotalPercepciones - TotalDeducciones;
    }

    public class Percepcion
    {
        public string Concepto { get; set; }
        public double Importe { get; set; }
    }

    public class Deduccion
    {
        public string Concepto { get; set; }
        public double Importe { get; set; }
    }
}
