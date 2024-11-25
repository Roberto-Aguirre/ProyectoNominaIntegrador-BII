using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.DTOS;

public partial class SatOrigenRecursoDTO
{
    public int Id { get; set; }

    public string OrigenRecursoSat { get; set; } = null!;

    public string DscripcionSat { get; set; } = null!;

    public string Estatus { get; set; } = null!;


}
