using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.Models;

public partial class NominaDetalle
{
    public int Id { get; set; }

    public int EmpresaId { get; set; }

    public int PeriodoId { get; set; }

    public int TrabajadorId { get; set; }

    public int IncidenciaId { get; set; }

    public int TipoIncapacidadId { get; set; }

    public decimal DiasPagados { get; set; }

    public decimal HorasExtra { get; set; }

    public decimal Importe { get; set; }

    public decimal Gravado { get; set; }

    public decimal Exento { get; set; }

    public decimal IsraPagar { get; set; }

    public decimal BaseImpuesto { get; set; }

    public int TipoCaptura { get; set; }

    public string? Comentarios { get; set; }

    public string? Estatus { get; set; }

    public virtual Empresa Empresa { get; set; } = null!;

    public virtual Trabajador Trabajador { get; set; } = null!;
}
