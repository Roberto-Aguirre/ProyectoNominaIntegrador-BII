using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII;

public partial class SatTipoJornadum
{
    public int Id { get; set; }

    public string ClaveSat { get; set; } = null!;

    public string DescripcionSat { get; set; } = null!;

    public decimal Horas { get; set; }

    public string Estatus { get; set; } = null!;

    public virtual ICollection<Trabajador> Trabajadors { get; set; } = new List<Trabajador>();
}
