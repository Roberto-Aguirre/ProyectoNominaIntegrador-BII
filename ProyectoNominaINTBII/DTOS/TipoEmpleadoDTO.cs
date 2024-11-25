using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.DTOS;

public partial class TipoEmpleadoDTO
{
    public int Id { get; set; }

    public string Descipcion { get; set; } = null!;

    public int? EmpresaId { get; set; }

    public string Estatus { get; set; } = null!;

}
