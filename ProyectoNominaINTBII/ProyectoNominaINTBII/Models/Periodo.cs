using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.Models;

public partial class Periodo
{
    public int Id { get; set; }

    public int SatPeriocidadPagoId { get; set; }

    public int? Periodo1 { get; set; }

    public string Descripcion { get; set; } = null!;

    public int EmpresaId { get; set; }

    public DateTime? FechaInicial { get; set; }

    public DateTime? FechaFinal { get; set; }

    public string Estatus { get; set; } = null!;

    public virtual Empresa Empresa { get; set; } = null!;

    public virtual ICollection<InicioNomina> InicioNominas { get; set; } = new List<InicioNomina>();

    public virtual ICollection<NominaDetalle> NominaDetalles { get; set; } = new List<NominaDetalle>();

    public virtual ICollection<Nomina> Nominas { get; set; } = new List<Nomina>();

    public virtual SatPeriocidadPago SatPeriocidadPago { get; set; } = null!;
}
