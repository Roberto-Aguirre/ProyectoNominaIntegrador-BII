using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.DTOS;

public partial class PuestoDTO
{
    public int Id { get; set; }

    public int Categoria { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal? SalarioIni { get; set; }

    public decimal? SalarioFin { get; set; }

    public int? EmpresaId { get; set; }

    public string Estatus { get; set; } = null!;

   
  
}
