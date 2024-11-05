using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.Models;
public partial class TipoEmpleado
{
    public int Id { get; set; }

    public string Descipcion { get; set; } = null!;

    public int? Empresa { get; set; }

    public string Estatus { get; set; } = null!;

    public virtual Empresa IdNavigation { get; set; } = null!;

    public virtual Trabajador? Trabajador { get; set; }
}
