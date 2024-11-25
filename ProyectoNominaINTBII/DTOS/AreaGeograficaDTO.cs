using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.DTOS;

public partial class AreaGeograficaDTO
{
    public int Id { get; set; }

    public string Clave { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string Estatus { get; set; } = null!;

    
}
