using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.Models;
public partial class Categorias
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public int? Empresa { get; set; }

    public string Estatus { get; set; } = null!;

    public virtual Empresa IdNavigation { get; set; } = null!;

    public virtual Puesto? Puesto { get; set; }
}
