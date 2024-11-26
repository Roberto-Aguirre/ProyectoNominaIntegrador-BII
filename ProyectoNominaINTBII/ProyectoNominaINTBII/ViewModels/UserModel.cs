using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoNominaINTBII.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoNominaINTBII.ViewModels
{
    public class UserModel
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public int TipoEmpleadoId { get; set; }
        public int TipoContratoId { get; set; }
        public string NumEmpleado { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int SexoId { get; set; }
        public int EstadoCivilId { get; set; }
        public DateTime FechaNac { get; set; }
        public string Calle { get; set; }
        public string NumeroExt { get; set; }
        public string NumeroInt { get; set; }
        public string Colonia { get; set; }
        public string CP { get; set; }
        public int PaisId { get; set; }
        public int MunicipioId { get; set; }
        public int EstadoId { get; set; }
        public string TelefonoMovil { get; set; }
        public string TelefonoFijo { get; set; }
        public string RFC { get; set; }
        public string CURP { get; set; }
        public string NSS { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaBaja { get; set; }
        public int PeriodicidadPagoId { get; set; }

        public int FormaPagoId { get; set; }
        public int CuentaBanco { get; set; }
        public string CLABE { get; set; }
        public int BancoId { get; set; }
        public string Email { get; set; }
        public decimal Salario { get; set; }
        public decimal SalarioDiario { get; set; }
        public decimal SalarioDiarioInte { get; set; }
        public bool CumpleReqDisminucion { get; set; }
        public int TipoRegimenId { get; set; }
        public int PuestoId { get; set; }
        public int DepartamentoId { get; set; }
        public int BaseCotizacionId { get; set; }
        public int TipoJornadaId { get; set; }
        public int OrigenRecursoId { get; set; }
        public decimal PorcentajePresFed { get; set; }
        public decimal MontoPropio { get; set; }
        public bool NominaGen { get; set; }
        public int EmpresaRegimenPatId { get; set; }
        public int EstatusTimbrado { get; set; }
        public int MotivoNoTimbrarId { get; set; }
        public string Estatus { get; set; }


        [Required]
        [Display(Name = "Nombre de usuario")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Rol")]
        public string Role { get; set; }

        public List<SelectListItem> Sexos { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> EstadosCiviles { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Paises { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Municipios { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Estados { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Bancos { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> TiposRegimen { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Puestos { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Departamentos { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> TiposJornada { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> FormasPago { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> PeriodicidadesPago { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> TiposContrato { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> TiposEmpleado { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> TiposRegimenFiscal { get; set; } = new List<SelectListItem>();

        // Constructor para inicializar las listas
        public UserModel()
        {
            InicializarListas();
        }

        private void InicializarListas()
        {
            Sexos = new List<SelectListItem>();
            EstadosCiviles = new List<SelectListItem>();
            Paises = new List<SelectListItem>();
            Municipios = new List<SelectListItem>();
            Estados = new List<SelectListItem>();
            Bancos = new List<SelectListItem>();
            TiposRegimen = new List<SelectListItem>();
            Puestos = new List<SelectListItem>();
            Departamentos = new List<SelectListItem>();
            TiposJornada = new List<SelectListItem>();
            FormasPago = new List<SelectListItem>();
            PeriodicidadesPago = new List<SelectListItem>();
            TiposContrato = new List<SelectListItem>();
            TiposEmpleado = new List<SelectListItem>();
            TiposRegimenFiscal = new List<SelectListItem>();
        }
    }
}