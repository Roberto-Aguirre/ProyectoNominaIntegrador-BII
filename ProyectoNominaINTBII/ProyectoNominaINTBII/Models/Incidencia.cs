namespace ProyectoNominaINTBII.Models;

public partial class Incidencia
{
    public int Id { get; set; }

    public int TipoPercepcion { get; set; }

    public int TipoDeduccion { get; set; }

    public int TipoNominaId { get; set; }

    public int AplicacionId { get; set; }

    public int TipoAplicacionNominaId { get; set; }

    public int? Operacion { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool Obligatorio { get; set; }

    public int Especie { get; set; }

    public int? EmpresaId { get; set; }

    public decimal Porcentaje { get; set; }

    public decimal Monto { get; set; }

    public bool TipoPrevSoc { get; set; }

    public string Estatus { get; set; } = null!;

    public virtual AplicacionNomina Aplicacion { get; set; } = null!;

    public virtual ICollection<NominaDetalle> NominaDetalles { get; set; } = new List<NominaDetalle>();

    public virtual TipoNominaSat TipoAplicacionNomina { get; set; } = null!;

    public virtual TipoNomina TipoNomina { get; set; } = null!;
}
