using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.Models;
public partial class SatPais
{
    public int Id { get; set; }

    public string ClaveSat { get; set; } = null!;

    public string DescripcionSat { get; set; } = null!;

    public string? FmtoCodPostalSat { get; set; }

    public string? FmotRegIdenTribSat { get; set; }

    public string? ValidaRegIdenTribSat { get; set; }

    public string? AgrupacionesSat { get; set; }

    public string Estatus { get; set; } = null!;

    public virtual Empresa? Empresa { get; set; }

    public virtual SatEstado? SatEstado { get; set; }

    public virtual Trabajador? Trabajador { get; set; }
}
