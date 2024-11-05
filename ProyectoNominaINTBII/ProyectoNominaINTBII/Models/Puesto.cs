using System;
using System.Collections.Generic;
namespace ProyectoNominaINTBII.Models;

public partial class Puesto
{
    public int Id { get; set; }

    public int Categoria { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal? SalarioIni { get; set; }

    public decimal? SalarioFin { get; set; }

    public int? Empresa { get; set; }

    public string Estatus { get; set; } = null!;

    public virtual Categorias IdNavigation { get; set; } = null!;

    public virtual Trabajador? Trabajador { get; set; }
}
