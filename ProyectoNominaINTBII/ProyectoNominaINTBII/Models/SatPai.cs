using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.Models;

public partial class SatPai
{
    public int Id { get; set; }

    public string ClaveSat { get; set; } = null!;

    public string DescripcionSat { get; set; } = null!;

    public string? FmtoCodPostalSat { get; set; }

    public string? FmotRegIdenTribSat { get; set; }

    public string? ValidaRegIdenTribSat { get; set; }

    public string? AgrupacionesSat { get; set; }

    public string Estatus { get; set; } = null!;

    public virtual ICollection<Empresa> Empresas { get; set; } = new List<Empresa>();

    public virtual ICollection<Trabajador> Trabajadors { get; set; } = new List<Trabajador>();
}
