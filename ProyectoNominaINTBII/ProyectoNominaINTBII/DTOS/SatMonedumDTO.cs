using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.DTOS;

public partial class SatMonedumDTO
{
    public int Id { get; set; }

    public string ClaveSat { get; set; } = null!;

    public string DescripcionSat { get; set; } = null!;

    public int DecimalesSat { get; set; }

    public int? PorcentajeVariacionSat { get; set; }

    public DateTime? FechaInicioVariacionSat { get; set; }

    public DateTime? FechaFinVigenciaSat { get; set; }

    public string Estatus { get; set; } = null!;

}
