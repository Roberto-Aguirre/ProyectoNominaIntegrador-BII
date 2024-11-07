using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.Models;

public partial class SatTipoHora
{
    public int Id { get; set; }

    public string ClaveSat { get; set; } = null!;

    public string DescripcionSat { get; set; } = null!;

    public decimal Monto { get; set; }

    public string Estatus { get; set; } = null!;

    public virtual ICollection<Empresa>? Empresas { get; set; } = new List<Empresa>();
}
