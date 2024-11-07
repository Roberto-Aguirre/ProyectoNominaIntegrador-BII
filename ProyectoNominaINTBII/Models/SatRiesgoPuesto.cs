using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.Models;

public partial class SatRiesgoPuesto
{
    public int Id { get; set; }

    public string ClaveSat { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public DateTime FechaInicioVigencia { get; set; }

    public DateTime FechaFinVigencia { get; set; }

    public string Estatus { get; set; } = null!;

    public virtual ICollection<EmpresaRegPat>? EmpresaRegPats { get; set; } = new List<EmpresaRegPat>();
}
