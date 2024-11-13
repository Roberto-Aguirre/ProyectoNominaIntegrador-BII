using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.Models;

public partial class Empresa
{
    public int Id { get; set; }

    public DateTime FechaAlta { get; set; }

    public string Rfc { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Calle { get; set; } = null!;

    public string NumeroExt { get; set; } = null!;

    public string? NumeroInt { get; set; }

    public string Colonia { get; set; } = null!;

    public string Cp { get; set; } = null!;

    public string Curp { get; set; } = null!;

    public int MunicipioId { get; set; }

    public int EstadoId { get; set; }

    public int PaisId { get; set; }

    public string Email { get; set; } = null!;

    public string TipoComprobante { get; set; } = null!;

    public string? PathLogo { get; set; }

    public string? PathCertificadoSat { get; set; }

    public string? PathLlaveSat { get; set; }

    public string? ContraseñaSat { get; set; }

    public string? ProveedorSat { get; set; }

    public string? PathTimbrado { get; set; }

    public int MonedaId { get; set; }

    public int RegimenFiscalId { get; set; }

    public bool CumpleReqCuotas { get; set; }

    public string? ClaveImss { get; set; }

    public string? ClaveInfonavit { get; set; }

    public string? ClaveFonacot { get; set; }

    public string? LugarExpedicion { get; set; }

    public int TipoEmpresaId { get; set; }

    public int TipoHoraId { get; set; }

    public decimal? PorcentajePresFed { get; set; }

    public string TelefonoWhatsApp { get; set; } = null!;

    public string? TelefonoFijo { get; set; }

    public int TipoConstitucionId { get; set; }

    public string Estatus { get; set; } = null!;

    public virtual ICollection<EmpresaRegPat> EmpresaRegPats { get; set; } = new List<EmpresaRegPat>();

    public virtual SatEstado Estado { get; set; } = null!;

    public virtual SatMonedum Moneda { get; set; } = null!;

    public virtual SatMunicipio Municipio { get; set; } = null!;

    public virtual SatPai Pais { get; set; } = null!;

    public virtual ICollection<Puesto> Puestos { get; set; } = new List<Puesto>();

    public virtual SatRegimenFiscal RegimenFiscal { get; set; } = null!;

    public virtual TipoConstitucion TipoConstitucion { get; set; } = null!;

    public virtual ICollection<TipoEmpleado> TipoEmpleados { get; set; } = new List<TipoEmpleado>();

    public virtual TipoEmpresa TipoEmpresa { get; set; } = null!;

    public virtual SatTipoHora TipoHora { get; set; } = null!;

    public virtual ICollection<Trabajador> Trabajadors { get; set; } = new List<Trabajador>();
}
