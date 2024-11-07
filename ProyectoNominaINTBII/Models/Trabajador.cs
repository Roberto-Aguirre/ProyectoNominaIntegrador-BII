using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.Models;

public partial class Trabajador
{
    public int Id { get; set; }

    public int EmpresaId { get; set; }

    public int TipoEmpleadoId { get; set; }

    public int TipoContratoId { get; set; }

    public string NumEmpleado { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string ApellidoPaterno { get; set; }

    public string ApellidoMaterno { get; set; }

    public int SexoId { get; set; }

    public int EstadoCivilId { get; set; }

    public DateTime FechaNac { get; set; }

    public string Calle { get; set; }

    public string NumeroExt { get; set; }

    public string NumeroInt { get; set; }

    public string Colonia { get; set; }

    public string Cp { get; set; } = null!;

    public int PaisId { get; set; }

    public int MunicipioId { get; set; }

    public int EstadoId { get; set; }

    public string TelefonoMovil { get; set; }

    public string TelefonoFijo { get; set; }

    public string Rfc { get; set; }

    public string Curp { get; set; } = null!;

    public string Nss { get; set; }

    public DateTime FechaIngreso { get; set; }

    public DateTime FechaBaja { get; set; }

    public int PeriocidadPagoId { get; set; }

    public int FormaPagoId { get; set; }

    public int CuentaBanco { get; set; }

    public string Clabe { get; set; } = null!;

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
