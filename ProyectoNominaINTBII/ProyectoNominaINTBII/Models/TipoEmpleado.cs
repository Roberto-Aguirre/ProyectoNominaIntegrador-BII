using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.Models;

public partial class TipoEmpleado
{
    public int Id { get; set; }

    public string Descipcion { get; set; } = null!;

    public required int EmpresaId { get; set; }

    public string Estatus { get; set; } = null!;

    public virtual Empresa? Empresa { get; set; }

    public virtual ICollection<Trabajador>? Trabajadors { get; set; } = new List<Trabajador>();
}
