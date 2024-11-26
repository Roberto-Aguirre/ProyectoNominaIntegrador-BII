namespace ProyectoNominaINTBII.Models;

public partial class AplicacionNomina
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Incidencia> Incidencia { get; set; } = new List<Incidencia>();
}
