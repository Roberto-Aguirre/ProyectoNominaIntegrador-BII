using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.Models;
public partial class AreaGeografica
{
    public int Id { get; set; }

    public string Clave { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string Estatus { get; set; } = null!;

    public virtual EmpresaRegPat? EmpresaRegPat { get; set; }
}
