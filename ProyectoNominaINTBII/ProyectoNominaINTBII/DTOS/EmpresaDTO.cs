using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.DTOS;

public partial class EmpresaDTO
{
    public int Id { get; set; }

    public DateTime FechaAlta { get; set; }

    public string Rfc { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Calle { get; set; }

    public string NumeroExt { get; set; }

    public string NumeroInt { get; set; }

    public string Colonia { get; set; }

    public string Cp { get; set; } = null!;

    public string Curp { get; set; }

    public int MunicipioId { get; set; }

    public int EstadoId { get; set; }

    public int PaisId { get; set; }

    public string Email { get; set; }

    public string TipoComprobante { get; set; }

    public string PathLogo { get; set; }

    public string PathCertificadoSat { get; set; }

    public string PathLlaveSat { get; set; }

    public string ContraseñaSat { get; set; }

    public string ProveedorSat { get; set; }

    public string PathTimbrado { get; set; }

    public int MonedaId { get; set; }

    public int RegimenFiscalId { get; set; }

    public bool CumpleReqCuotas { get; set; }

    public string ClaveImss { get; set; }

    public string ClaveInfonavit { get; set; }

    public string ClaveFonacot { get; set; }

    public string LugarExpedicion { get; set; }

    public int TipoEmpresaId { get; set; }

    public int TipoHoraId { get; set; }

    public decimal PorcentajePresFed { get; set; }

    public string TelefonoWhatsApp { get; set; }

    public string TelefonoFijo { get; set; }

    public int TipoConstitucionId { get; set; }

    public string Estatus { get; set; } = null!;


}
