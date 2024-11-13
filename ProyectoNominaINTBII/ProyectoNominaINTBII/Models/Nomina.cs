using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.Models;

public partial class Nomina
{
    public int Id { get; set; }

    public int EmpresaId { get; set; }

    public int Ejercicio { get; set; }

    public DateTime? FechaInicial { get; set; }

    public DateTime? FechaFinal { get; set; }

    public DateTime? FechaPago { get; set; }

    public int SatPeriocidadPagoId { get; set; }

    public int PeriodoId { get; set; }

    public int SatTipoContratoId { get; set; }

    public int NominaExtraordinariaId { get; set; }

    public string? ConceptoNomina { get; set; }

    public string? ConceptoTimbrado { get; set; }

    public int TotalTrabajadores { get; set; }

    public decimal? TotalPercepciones { get; set; }

    public decimal TotalDeducciones { get; set; }

    public bool Extraordinaria { get; set; }

    public bool Generada { get; set; }

    public bool Autorizada { get; set; }

    public bool Timbrada { get; set; }

    public bool Cerrada { get; set; }

    public string Estatus { get; set; } = null!;

    public virtual Empresa Empresa { get; set; } = null!;

    public virtual SatPeriocidadPago SatPeriocidadPago { get; set; } = null!;

    public virtual SatTipoContrato SatTipoContrato { get; set; } = null!;
}
