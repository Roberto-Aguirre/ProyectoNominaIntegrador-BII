using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII;

public partial class Puesto
{
    public int Id { get; set; }

    public int Categoria { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal? SalarioIni { get; set; }

    public decimal? SalarioFin { get; set; }

    public int? EmpresaId { get; set; }

    public string Estatus { get; set; } = null!;

    public virtual Categorium CategoriaNavigation { get; set; } = null!;

    public virtual Empresa? Empresa { get; set; }

    public virtual ICollection<Trabajador> Trabajadors { get; set; } = new List<Trabajador>();
}
