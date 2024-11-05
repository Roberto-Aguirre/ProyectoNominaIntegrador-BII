using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.Models;
public partial class SatTipoRegimen
{
    public int Id { get; set; }

    public string ClaveSat { get; set; } = null!;

    public string DescripcionSat { get; set; } = null!;

    public DateTime? FechaInicioVigenciaSat { get; set; }

    public DateTime? FechaFinVigenciaSat { get; set; }

    public string Estatus { get; set; } = null!;

    public virtual Trabajador? Trabajador { get; set; }
}
