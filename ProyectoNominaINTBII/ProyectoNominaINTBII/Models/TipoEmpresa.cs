using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.Models;
public partial class TipoEmpresa
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Estatus { get; set; } = null!;

    public virtual Empresa? Empresa { get; set; }
}
