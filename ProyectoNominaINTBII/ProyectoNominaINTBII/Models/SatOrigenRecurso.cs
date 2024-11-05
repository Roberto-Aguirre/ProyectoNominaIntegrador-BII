using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.Models;
public partial class SatOrigenRecurso
{
    public int Id { get; set; }

    public string OrigenRecursoSat { get; set; } = null!;

    public string DscripcionSat { get; set; } = null!;

    public string Estatus { get; set; } = null!;

    public virtual Trabajador? Trabajador { get; set; }
}
