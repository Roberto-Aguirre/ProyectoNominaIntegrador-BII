﻿using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.Models;

public partial class Departamento
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public required int EmpresaId { get; set; } 

    public required decimal MontoPropio { get; set; } 

    public string Estatus { get; set; } = null!;

    public virtual ICollection<Trabajador>? Trabajadors { get; set; } = new List<Trabajador>();
}