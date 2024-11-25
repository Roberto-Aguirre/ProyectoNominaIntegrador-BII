using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.Models;

public partial class TipoNominaSat
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Incidencia> Incidencia { get; set; } = new List<Incidencia>();
}
