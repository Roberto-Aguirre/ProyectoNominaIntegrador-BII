using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.DTOS;

public partial class SatTipoJornadumDTO
{
    public int Id { get; set; }

    public string ClaveSat { get; set; } = null!;

    public string DescripcionSat { get; set; } = null!;

    public decimal Horas { get; set; }

    public string Estatus { get; set; } = null!;


}
