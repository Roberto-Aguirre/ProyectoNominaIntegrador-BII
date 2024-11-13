using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoNominaINTBII.Models
{
    public class UserModel
    {
        // Propiedad agregada para Fecha de Ingreso
        [Required(ErrorMessage = "La Fecha de Ingreso es obligatoria")]
        public DateTime FechaIngreso { get; set; }
     

        // Propiedad calculada para Nombre Completo
        public string NombreCompleto
        {
            get
            {
                return $"{Nombre} {NumeroEmpleado}";
            }
        }

        // Propiedades generales
        [Required(ErrorMessage = "El campo Id es obligatorio")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Número de Empleado es obligatorio")]
        public string NumeroEmpleado { get; set; }

        [Required(ErrorMessage = "El RFC es obligatorio")]
        public string RFC { get; set; }

        [Required(ErrorMessage = "El CURP es obligatorio")]
        public string CURP { get; set; }

        [Required(ErrorMessage = "El Régimen Fiscal es obligatorio")]
        public string RegimenFiscal { get; set; }

        [Required(ErrorMessage = "El Número IMSS es obligatorio")]
        public string NoIMSS { get; set; }

        [Required(ErrorMessage = "La Fecha de Inicio es obligatoria")]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "El Régimen es obligatorio")]
        public string Regimen { get; set; }

        [Required(ErrorMessage = "El Tipo de Jornada es obligatorio")]
        public string TipoJornada { get; set; }

        [Required(ErrorMessage = "El SBC es obligatorio")]
        public decimal SBC { get; set; }

        [Required(ErrorMessage = "El SDI es obligatorio")]
        public decimal SDI { get; set; }

        [Required(ErrorMessage = "El Ejercicio es obligatorio")]
        public string Ejercicio { get; set; }

        [Required(ErrorMessage = "El Folio es obligatorio")]
        public string Folio { get; set; }

        [Required(ErrorMessage = "El Periodo de Pago es obligatorio")]
        public string PeriodoPago { get; set; }

        [Required(ErrorMessage = "La Fecha de Pago es obligatoria")]
        public DateTime FechaPago { get; set; }

        [Required(ErrorMessage = "La Periodicidad es obligatoria")]
        public string Periodicidad { get; set; }

        [Required(ErrorMessage = "Los Días Pagados son obligatorios")]
        public int DiasPagados { get; set; }

        [Required(ErrorMessage = "Las Faltas son obligatorias")]
        public int Faltas { get; set; }

        // Información de contacto adicional
        [Required(ErrorMessage = "El Teléfono es obligatorio")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El Email es obligatorio")]
        public string Email { get; set; }

        // Campos que estaban causando error
        [Required(ErrorMessage = "El Departamento es obligatorio")]
        public string Departamento { get; set; }

        [Required(ErrorMessage = "El Puesto es obligatorio")]
        public string Puesto { get; set; }

        [Required(ErrorMessage = "El Salario Diario es obligatorio")]
        public decimal SalarioDiario { get; set; }

        // Información para el login
        [Required(ErrorMessage = "El Username es obligatorio")]
        public string Username { get; set; }

        [Required(ErrorMessage = "El Password es obligatorio")]
        public string Password { get; set; }

        [Required(ErrorMessage = "El Role es obligatorio")]
        public string Role { get; set; }  // Puede ser 'admin' o 'empleado'

        public bool IsActive { get; set; } // true = Activo, false = Inactivo
    }
}
