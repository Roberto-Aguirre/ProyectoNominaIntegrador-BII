﻿using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.DTOS;


public partial class BaseCotizacionDTO
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Estatus { get; set; } = null!;


}