using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.DTOS;

public partial class SatRegimenFiscalDTO
{
    public int Id { get; set; }

    public string ClaveSat { get; set; } = null!;

    public string DescripcionSat { get; set; } = null!;

    public string PersonaFisicaSat { get; set; } = null!;

    public string PersonaMoralSat { get; set; } = null!;

    public DateTime? FechaInicioVigenciaSat { get; set; }

    public DateTime? FechaFinVigenciaSat { get; set; }

    public string Estatus { get; set; } = null!;


}
