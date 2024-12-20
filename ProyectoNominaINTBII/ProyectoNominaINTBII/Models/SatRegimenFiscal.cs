﻿using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.Models;

public partial class SatRegimenFiscal
{
    public int Id { get; set; }

    public string ClaveSat { get; set; } = null!;

    public string DescripcionSat { get; set; } = null!;

    public string PersonaFisicaSat { get; set; } = null!;

    public string PersonaMoralSat { get; set; } = null!;

    public DateTime? FechaInicioVigenciaSat { get; set; }

    public DateTime? FechaFinVigenciaSat { get; set; }

    public string Estatus { get; set; } = null!;

    public virtual ICollection<Empresa> Empresas { get; set; } = new List<Empresa>();
}
