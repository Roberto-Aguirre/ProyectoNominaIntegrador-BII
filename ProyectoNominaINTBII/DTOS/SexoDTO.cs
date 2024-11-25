using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.DTOS;

public partial class SexoDTO
{
    public int Id { get; set; }

    public string Descipcion { get; set; } = null!;

    public string Estatus { get; set; } = null!;

}
