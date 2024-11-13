using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.Models;

public partial class SatPeriocidadPago
{
    public int Id { get; set; }

    public string ClaveSat { get; set; } = null!;

    public string DescripcionSat { get; set; } = null!;

    public int Dias { get; set; }

    public string? DiasValidos { get; set; }

    public string Estatus { get; set; } = null!;

    public virtual ICollection<InicioNomina> InicioNominas { get; set; } = new List<InicioNomina>();

    public virtual ICollection<Nomina> Nominas { get; set; } = new List<Nomina>();

    public virtual ICollection<Periodo> Periodos { get; set; } = new List<Periodo>();

    public virtual ICollection<Trabajador> Trabajadors { get; set; } = new List<Trabajador>();
}
