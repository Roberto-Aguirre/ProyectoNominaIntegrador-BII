using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.Models;

public partial class SatFormaPago
{
    public int Id { get; set; }

    public string ClaveSat { get; set; } = null!;

    public string DescripcionSat { get; set; } = null!;

    public string BancarizadoSat { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public DateTime FechaInicioVigenciaSat { get; set; }

    public DateTime FechaFinVigenciaSat { get; set; }

    public string Estatus { get; set; } = null!;

    public virtual ICollection<Trabajador> Trabajadors { get; set; } = new List<Trabajador>();
}
