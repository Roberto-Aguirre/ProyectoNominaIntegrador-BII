using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.Models;

public partial class Periodo
{
    public int Id { get; set; }

    public int? SatPeriocidadPagoId { get; set; }

    public string Descripcion { get; set; } = null!;

    public int? EmpresaId { get; set; }

    public string Estatus { get; set; } = null!;

    public virtual Empresa? Empresa { get; set; }

    public virtual SatPeriocidadPago? SatPeriocidadPago { get; set; }
}
