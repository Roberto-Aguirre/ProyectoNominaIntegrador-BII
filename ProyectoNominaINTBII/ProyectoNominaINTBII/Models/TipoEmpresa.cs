using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII;

public partial class TipoEmpresa
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Estatus { get; set; } = null!;

    public virtual ICollection<Empresa> Empresas { get; set; } = new List<Empresa>();
}
