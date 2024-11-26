public class CompanyInfoModel
{
    public int Id { get; set; }
    public DateTime FechaAlta { get; set; }
    public string RFC { get; set; }
    public string Nombre { get; set; }
    public string Calle { get; set; }
    public string NumeroExt { get; set; }
    public string NumeroInt { get; set; }
    public string Colonia { get; set; }
    public string CP { get; set; }
    public string CURP { get; set; }
    public int MunicipioId { get; set; }
    public int EstadoId { get; set; }
    public int PaisId { get; set; }
    public string Email { get; set; }
    public string TipoComprobante { get; set; }
    public string PathLogo { get; set; }
    public string PathCertificadoSAT { get; set; }
    public string PathLlaveSAT { get; set; }
    public string ContraseñaSAT { get; set; }
    public string ProveedorSAT { get; set; }
    public string PathTimbrado { get; set; }
    public int MonedaId { get; set; }
    public int RegimenFiscalId { get; set; }
    public bool CumpleReqCuotas { get; set; }
    public string ClaveIMSS { get; set; }
    public string ClaveINFONAVIT { get; set; }
    public string ClaveFONACOT { get; set; }
    public string LugarExpedicion { get; set; }
    public int TipoEmpresaId { get; set; }
    public int TipoHoraId { get; set; }
    public decimal? PorcentajePresFed { get; set; }
    public string TelefonoWhatsApp { get; set; }
    public string TelefonoFijo { get; set; }
    public int TipoConstitucionId { get; set; }
    public string Estatus { get; set; }
}
