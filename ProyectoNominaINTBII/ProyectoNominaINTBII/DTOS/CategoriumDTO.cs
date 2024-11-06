using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.DTOS;

public partial class CategoriumDTO
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public int? EmpresaId { get; set; }

    public string Estatus { get; set; } = null!;

}
