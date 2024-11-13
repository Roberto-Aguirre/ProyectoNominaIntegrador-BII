using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.Models;

public partial class InicioNomina
{
    public int Id { get; set; }

    public int Ejercicio { get; set; }

    public int EmpresaId { get; set; }

    public int EmpresaRegPatId { get; set; }

    public int SatPeriocidadPagoId { get; set; }

    public int PeriodoId { get; set; }

    public DateTime? FechaInicial { get; set; }

    public DateTime? FechaFinal { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public DateTime? FechaCierre { get; set; }

    public string? EstatusEjercicio { get; set; }

    public int PeriodoActualId { get; set; }

    public string? Comentarios { get; set; }

    public string Estatus { get; set; } = null!;

    public virtual Empresa Empresa { get; set; } = null!;

    public virtual EmpresaRegPat EmpresaRegPat { get; set; } = null!;

    public virtual SatPeriocidadPago SatPeriocidadPago { get; set; } = null!;
}
