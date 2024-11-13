using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.Models;

public partial class SatMonedum
{
    public int Id { get; set; }

    public string ClaveSat { get; set; } = null!;

    public string DescripcionSat { get; set; } = null!;

    public required int DecimalesSat { get; set; }

    public required int PorcentajeVariacionSat { get; set; }

    public required DateTime FechaInicioVariacionSat { get; set; }

    public required DateTime FechaFinVigenciaSat { get; set; }

    public string Estatus { get; set; } = null!;

    public virtual ICollection<Empresa>? Empresas { get; set; } = new List<Empresa>();
}
