namespace ProyectoNominaINTBII.Models;

public partial class SatMonedum
{
    public int Id { get; set; }

    public string ClaveSat { get; set; } = null!;

    public string DescripcionSat { get; set; } = null!;

    public int DecimalesSat { get; set; }

    public int PorcentajeVariacionSat { get; set; }

    public DateTime? FechaInicioVariacionSat { get; set; }

    public DateTime? FechaFinVigenciaSat { get; set; }

    public string Estatus { get; set; } = null!;

    public virtual ICollection<Empresa> Empresas { get; set; } = new List<Empresa>();
}
