﻿using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.Models;

public partial class SatEstado
{
    public int Id { get; set; }

    public required int PaisId { get; set; }

    public string ClaveSat { get; set; } = null!;

    public string DescripcionSat { get; set; } = null!;

    public required DateTime FechaInicioVigenciaSat { get; set; }

    public required DateTime FechaFinVigenciaSat { get; set; }

    public required int FolioInegi { get; set; }

    public string Estatus { get; set; } = null!;

    public virtual ICollection<Empresa>? Empresas { get; set; } = new List<Empresa>();

    public virtual ICollection<Trabajador>? Trabajadors { get; set; } = new List<Trabajador>();
}