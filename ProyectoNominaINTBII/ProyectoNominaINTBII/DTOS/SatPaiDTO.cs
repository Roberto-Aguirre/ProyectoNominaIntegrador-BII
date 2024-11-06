using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.DTOS;

public partial class SatPaiDTO
{
    public int Id { get; set; }

    public string ClaveSat { get; set; } = null!;

    public string DescripcionSat { get; set; } = null!;

    public string? FmtoCodPostalSat { get; set; }

    public string? FmotRegIdenTribSat { get; set; }

    public string? ValidaRegIdenTribSat { get; set; }

    public string? AgrupacionesSat { get; set; }

    public string Estatus { get; set; } = null!;


}
