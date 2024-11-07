using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.Models;

public partial class Empresa
{
    public int Id { get; set; }

    public required DateTime FechaAlta { get; set; }

    public string Rfc { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public required string Calle { get; set; }

    public  string NumeroExt { get; set; } = null!;

    public string NumeroInt { get; set; } 

    public required string Colonia { get; set; }

    public string Cp { get; set; } = null!;

    public string Curp { get; set; } = null!;

    public required int MunicipioId { get; set; }

    public required int EstadoId { get; set; }

    public required int PaisId { get; set; }

    public string Email { get; set; } = null!;

    public string TipoComprobante { get; set; } 

    public string PathLogo { get; set; }

    public string PathCertificadoSat { get; set; }

    public string PathLlaveSat { get; set; }

    public string ContraseñaSat { get; set; }

    public string ProveedorSat { get; set; }

    public string PathTimbrado { get; set; }

    public required int MonedaId { get; set; }

    public required int RegimenFiscalId { get; set; }

    public required bool CumpleReqCuotas { get; set; }

    public string ClaveImss { get; set; } 

    public string ClaveInfonavit { get; set; }

    public string ClaveFonacot { get; set; }

    public string LugarExpedicion { get; set; }

    public required int TipoEmpresaId { get; set; }

    public required int TipoHoraId { get; set; }

    public decimal PorcentajePresFed { get; set; }

    public  string TelefonoWhatsApp { get; set; } = null!;

    public string TelefonoFijo { get; set; }

    public required int TipoConstitucionId { get; set; }

    public string Estatus { get; set; } = null!;

    public virtual ICollection<EmpresaRegPat>? EmpresaRegPats { get; set; } = null!;

    public virtual SatEstado? Estado { get; set; } = null!;

    public virtual SatMonedum? Moneda { get; set; } = null!;

    public virtual SatMunicipio? Municipio { get; set; } = null!;

    public virtual SatPai? Pais { get; set; } = null!;

    public virtual ICollection<Puesto>? Puestos { get; set; } = null!;

    public virtual SatRegimenFiscal? RegimenFiscal { get; set; } = null!;

    public virtual TipoConstitucion? TipoConstitucion { get; set; } = null!;

    public virtual ICollection<TipoEmpleado>? TipoEmpleados { get; set; } = null!;

    public virtual TipoEmpresa? TipoEmpresa { get; set; } = null!;

    public virtual SatTipoHora? TipoHora { get; set; } = null!;

    public virtual ICollection<Trabajador>? Trabajadors { get; set; } = null!;
}
