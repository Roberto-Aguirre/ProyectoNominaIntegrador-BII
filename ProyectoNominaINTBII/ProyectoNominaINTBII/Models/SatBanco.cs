using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII;

public partial class SatBanco
{
    public int Id { get; set; }

    public string ClaveSat { get; set; } = null!;

    public string DescripcionSat { get; set; } = null!;

    public string RazonSocialSat { get; set; } = null!;

    public DateTime? FechaInicioVigenciaSat { get; set; }

    public DateTime? FehcaFinVigenciaSat { get; set; }

    public int ClaveAbm { get; set; }

    public string Estatus { get; set; } = null!;

    public virtual ICollection<Trabajador> Trabajadors { get; set; } = new List<Trabajador>();
}
