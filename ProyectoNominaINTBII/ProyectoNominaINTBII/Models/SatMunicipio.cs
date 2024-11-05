using System;
using System.Collections.Generic;
namespace ProyectoNominaINTBII.Models;
public partial class SatMunicipio
{
    public int Id { get; set; }

    public int Estado { get; set; }

    public string ClaveSat { get; set; } = null!;

    public string DescripcionSat { get; set; } = null!;

    public DateTime? FechaInicioVigenciaSat { get; set; }

    public DateTime? FechaFinVigenciaSat { get; set; }

    public string Estatus { get; set; } = null!;

    public virtual Empresa? Empresa { get; set; }

    public virtual SatEstado IdNavigation { get; set; } = null!;

    public virtual Trabajador? Trabajador { get; set; }
}
