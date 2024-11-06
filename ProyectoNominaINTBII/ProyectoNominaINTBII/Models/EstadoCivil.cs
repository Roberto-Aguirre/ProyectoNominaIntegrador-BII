﻿using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII;

public partial class EstadoCivil
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Estatus { get; set; } = null!;

    public virtual ICollection<Trabajador> Trabajadors { get; set; } = new List<Trabajador>();
}