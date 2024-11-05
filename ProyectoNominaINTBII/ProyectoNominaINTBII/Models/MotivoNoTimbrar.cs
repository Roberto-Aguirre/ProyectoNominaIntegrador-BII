using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.Models;

public partial class MotivoNoTimbrar
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Estatus { get; set; } = null!;

    public virtual Trabajador? Trabajador { get; set; }
}
