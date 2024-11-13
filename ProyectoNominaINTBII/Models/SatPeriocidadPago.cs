using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.Models;

public partial class SatPeriocidadPago
{
    public int Id { get; set; }

    public string ClaveSat { get; set; } = null!;

    public string DescripcionSat { get; set; } = null!;

    public required DateTime FechaInicioVigenciaSat { get; set; }

    public required DateTime FechaFinVigenciaSat { get; set; }

    public int Dias { get; set; }

    public string DiasValidos { get; set; }

    public string Estatus { get; set; } = null!;

    public virtual ICollection<Trabajador>? Trabajadors { get; set; } = new List<Trabajador>();
}
