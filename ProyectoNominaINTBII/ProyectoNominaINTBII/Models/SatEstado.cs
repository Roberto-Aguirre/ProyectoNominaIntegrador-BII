using System;
using System.Collections.Generic;
namespace ProyectoNominaINTBII.Models;

public partial class SatEstado
{
    public int Id { get; set; }

    public int Pais { get; set; }

    public string ClaveSat { get; set; } = null!;

    public string DescripcionSat { get; set; } = null!;

    public DateTime? FechaInicioVigenciaSat { get; set; }

    public DateTime? FechaFinVigenciaSat { get; set; }

    public int FolioInegi { get; set; }

    public string Estatus { get; set; } = null!;

    public virtual Empresa? Empresa { get; set; }

    public virtual SatPais IdNavigation { get; set; } = null!;

    public virtual SatMunicipio? SatMunicipio { get; set; }

    public virtual Trabajador? Trabajador { get; set; }
}
