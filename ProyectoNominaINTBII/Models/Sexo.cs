using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.Models;

public partial class Sexo
{
    public int Id { get; set; }

    public string Descipcion { get; set; } = null!;

    public string Estatus { get; set; } = null!;

    public virtual ICollection<Trabajador>? Trabajadors { get; set; } = new List<Trabajador>();
}
