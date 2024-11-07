using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.Models;

public partial class Trabajador
{
    public int Id { get; set; }

    public required int EmpresaId { get; set; }

    public required int TipoEmpleadoId { get; set; }

    public required int TipoContratoId { get; set; }

    public string NumEmpleado { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string ApellidoPaterno { get; set; } = null!;

    public string ApellidoMaterno { get; set; } = null!;

    public required int SexoId { get; set; }

    public required int EstadoCivilId { get; set; }

    public DateTime FechaNac { get; set; }

    public string Calle { get; set; } = null!;

    public string NumeroExt { get; set; } = null!;

    public string NumeroInt { get; set; }

    public string Colonia { get; set; } = null!;

    public string Cp { get; set; } = null!;

    public required int PaisId { get; set; }

    public required int MunicipioId { get; set; }

    public required int EstadoId { get; set; }

    public string TelefonoMovil { get; set; } = null!;

    public string TelefonoFijo { get; set; }

    public string Rfc { get; set; }

    public string Curp { get; set; } = null!;

    public string Nss { get; set; } 

    public required DateTime FechaIngreso { get; set; }

    public required DateTime FechaBaja { get; set; }

    public required int PeriocidadPagoId { get; set; }

    public required int FormaPagoId { get; set; }

    public int CuentaBanco { get; set; }

    public string Clabe { get; set; } = null!;

    public required int BancoId { get; set; }

    public string Email { get; set; }

    public required decimal Salario { get; set; }

    public decimal SalarioDiario { get; set; }

    public decimal SalarioDiarioInte { get; set; }

    public bool CumpleReqDisminucion { get; set; }

    public required int TipoRegimenId { get; set; }

    public required int PuestoId { get; set; }

    public required int DepartamentoId { get; set; }

    public required int BaseCotizacionId { get; set; }

    public required int TipoJornadaId { get; set; }

    public required int OrigenRecursoId { get; set; }

    public decimal PorcentajePresFed { get; set; }

    public decimal MontoPropio { get; set; }

    public bool NominaGen { get; set; }

    public required int EmpresaRegimenPatId { get; set; }

    public required int EstatusTimbrado { get; set; }

    public required  int MotivoNoTimbrarId { get; set; }

    public string Estatus { get; set; } = null!;

    public virtual SatBanco? Banco { get; set; } = null!;

    public virtual BaseCotizacion? BaseCotizacion { get; set; } = null!;

    public virtual Departamento? Departamento { get; set; } = null!;

    public virtual Empresa? Empresa { get; set; } = null!;

    public virtual EmpresaRegPat? EmpresaRegimenPat { get; set; }

    public virtual SatEstado? Estado { get; set; } = null!;

    public virtual EstadoCivil? EstadoCivil { get; set; } = null!;

    public virtual SatFormaPago? FormaPago { get; set; } = null!;

    public virtual MotivoNoTimbrar? MotivoNoTimbrar { get; set; } = null!;

    public virtual SatMunicipio? Municipio { get; set; } = null!;

    public virtual SatOrigenRecurso? OrigenRecurso { get; set; } = null!;

    public virtual SatPai? Pais { get; set; } = null!;

    public virtual SatPeriocidadPago? PeriocidadPago { get; set; } = null!;

    public virtual Puesto? Puesto { get; set; } = null!;

    public virtual Sexo? Sexo { get; set; } = null!;

    public virtual SatTipoContrato? TipoContrato { get; set; } = null!;

    public virtual TipoEmpleado? TipoEmpleado { get; set; } = null!;

    public virtual SatTipoJornadum? TipoJornada { get; set; } = null!;

    public virtual SatTipoRegiman? TipoRegimen { get; set; } = null!;
}
