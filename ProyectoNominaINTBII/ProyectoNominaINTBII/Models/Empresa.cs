using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.Models;
public partial class Empresa
{
    public int Id { get; set; }

    public DateTime FechaAlta { get; set; }

    public string Rfc { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string? Calle { get; set; }

    public string? NumeroExt { get; set; }

    public string? NumeroInt { get; set; }

    public string? Colonia { get; set; }

    public string Cp { get; set; } = null!;

    public string? Curp { get; set; }

    public int Municipio { get; set; }

    public int Estado { get; set; }

    public int Pais { get; set; }

    public string? Email { get; set; }

    public string? TipoComprobante { get; set; }

    public string? PathLogo { get; set; }

    public string? PathCertificadoSat { get; set; }

    public string? PathLlaveSat { get; set; }

    public string? ContraseñaSat { get; set; }

    public string? ProveedorSat { get; set; }

    public string? PathTimbrado { get; set; }

    public int Moneda { get; set; }

    public int RegimenFiscal { get; set; }

    public bool CumpleReqCuotas { get; set; }

    public string? ClaveImss { get; set; }

    public string? ClaveInfonavit { get; set; }

    public string? ClaveFonacot { get; set; }

    public string? LugarExpedicion { get; set; }

    public int TipoEmpresa { get; set; }

    public int TipoHora { get; set; }

    public decimal? PorcentajePresFed { get; set; }

    public string? TelefonoWhatsApp { get; set; }

    public string? TelefonoFijo { get; set; }

    public int TipoConstitucion { get; set; }

    public string Estatus { get; set; } = null!;

    public virtual Categorias? Categorium { get; set; }

    public virtual Departamento? Departamento { get; set; }

    public virtual EmpresaRegPat? EmpresaRegPat { get; set; }

    public virtual SatMoneda Id1 { get; set; } = null!;

    public virtual SatMunicipio Id2 { get; set; } = null!;

    public virtual SatPais Id3 { get; set; } = null!;

    public virtual SatRegimenFiscal Id4 { get; set; } = null!;

    public virtual SatTipoHora Id5 { get; set; } = null!;

    public virtual TipoConstitucion Id6 { get; set; } = null!;

    public virtual TipoEmpresa Id7 { get; set; } = null!;

    public virtual SatEstado IdNavigation { get; set; } = null!;

    public virtual TipoEmpleado? TipoEmpleado { get; set; }

    public virtual Trabajador? Trabajador { get; set; }
}
