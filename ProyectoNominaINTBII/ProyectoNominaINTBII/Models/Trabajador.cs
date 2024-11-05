using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.Models;
public partial class Trabajador
{
    public int Id { get; set; }

    public int Empresa { get; set; }

    public int TipoEmpleado { get; set; }

    public int TipoContrato { get; set; }

    public string NumEmpleado { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string? ApellidoPaterno { get; set; }

    public string? ApellidoMaterno { get; set; }

    public int Sexo { get; set; }

    public int EstadoCivil { get; set; }

    public DateTime? FechaNac { get; set; }

    public string? Calle { get; set; }

    public string? NumeroExt { get; set; }

    public string? NumeroInt { get; set; }

    public string? Colonia { get; set; }

    public string Cp { get; set; } = null!;

    public int Pais { get; set; }

    public int Municipio { get; set; }

    public int Estado { get; set; }

    public string? TelefonoMovil { get; set; }

    public string? TelefonoFijo { get; set; }

    public string? Rfc { get; set; }

    public string Curp { get; set; } = null!;

    public string? Nss { get; set; }

    public DateTime FechaIngreso { get; set; }

    public DateTime? FechaBaja { get; set; }

    public int PeriocidadPago { get; set; }

    public int FormaPago { get; set; }

    public int CuentaBanco { get; set; }

    public string Clabe { get; set; } = null!;

    public int Banco { get; set; }

    public string? Email { get; set; }

    public decimal Salario { get; set; }

    public decimal SalarioDiario { get; set; }

    public decimal SalarioDiarioInte { get; set; }

    public bool CumpleReqDisminucion { get; set; }

    public int TipoRegimen { get; set; }

    public int Puesto { get; set; }

    public int Departamento { get; set; }

    public int BaseCotizacion { get; set; }

    public int TipoJornada { get; set; }

    public int OrigenRecurso { get; set; }

    public decimal? PorcentajePresFed { get; set; }

    public decimal? MontoPropio { get; set; }

    public bool NominaGen { get; set; }

    public int? EmpresaRegimenPat { get; set; }

    public int EstatusTimbrado { get; set; }

    public int MotivoNoTimbrar { get; set; }

    public string? Estatus { get; set; }

    public virtual Departamento Id1 { get; set; } = null!;

    public virtual SatMunicipio Id10 { get; set; } = null!;

    public virtual SatOrigenRecurso Id11 { get; set; } = null!;

    public virtual SatPais Id12 { get; set; } = null!;

    public virtual SatPeriocidadPago Id13 { get; set; } = null!;

    public virtual SatTipoContrato Id14 { get; set; } = null!;

    public virtual SatTipoJornada Id15 { get; set; } = null!;

    public virtual SatTipoRegimen Id16 { get; set; } = null!;

    public virtual Sexo Id17 { get; set; } = null!;

    public virtual TipoEmpleado Id18 { get; set; } = null!;

    public virtual Empresa Id2 { get; set; } = null!;

    public virtual EmpresaRegPat Id3 { get; set; } = null!;

    public virtual EstadoCivil Id4 { get; set; } = null!;

    public virtual MotivoNoTimbrar Id5 { get; set; } = null!;

    public virtual Puesto Id6 { get; set; } = null!;

    public virtual SatBanco Id7 { get; set; } = null!;

    public virtual SatEstado Id8 { get; set; } = null!;

    public virtual SatFormaPago Id9 { get; set; } = null!;

    public virtual BaseCotizacion IdNavigation { get; set; } = null!;
}
