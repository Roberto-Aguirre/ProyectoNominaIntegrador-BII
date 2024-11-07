using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.DTOS;

public partial class SatTipoContratoDTO
{
    public int Id { get; set; }

    public string ClaveSat { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string Estatus { get; set; } = null!;


}
