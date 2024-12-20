﻿using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.Models;

public partial class SatTipoContrato
{
    public int Id { get; set; }

    public string ClaveSat { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string Estatus { get; set; } = null!;

    public virtual ICollection<Nomina> Nominas { get; set; } = new List<Nomina>();

    public virtual ICollection<Trabajador> Trabajadors { get; set; } = new List<Trabajador>();
}
