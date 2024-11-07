using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.DTOS;

public partial class SatPeriocidadPagoDTO
{
    public int Id { get; set; }

    public string ClaveSat { get; set; } = null!;

    public string DescripcionSat { get; set; } = null!;

    public DateTime? FechaInicioVigenciaSat { get; set; }

    public DateTime? FechaFinVigenciaSat { get; set; }

    public int Dias { get; set; }

    public string? DiasValidos { get; set; }

    public string Estatus { get; set; } = null!;

 
}
