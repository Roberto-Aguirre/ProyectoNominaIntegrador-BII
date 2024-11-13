using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.Models;

public partial class Categorium
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public int EmpresaId { get; set; }

    public string Estatus { get; set; } = null!;

    public virtual ICollection<Puesto> Puestos { get; set; } = new List<Puesto>();
}
