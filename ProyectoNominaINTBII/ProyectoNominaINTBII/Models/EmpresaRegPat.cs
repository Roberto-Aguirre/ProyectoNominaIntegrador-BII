using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.Models;
public partial class EmpresaRegPat
{
    public int Id { get; set; }

    public int Empresa { get; set; }

    public int AreaGeografica { get; set; }

    public int RiesgoPuesto { get; set; }

    public string? RegistroPatronal { get; set; }

    public string? LugarExpedicion { get; set; }

    public string? PathCertificadoSat { get; set; }

    public string? PathLlaveSat { get; set; }

    public string? PassSat { get; set; }

    public DateTime? VigenciaInicial { get; set; }

    public DateTime? VigenciaFinal { get; set; }

    public string? NumeroSerie { get; set; }

    public virtual Empresa Id1 { get; set; } = null!;

    public virtual SatRiesgoPuesto Id2 { get; set; } = null!;

    public virtual AreaGeografica IdNavigation { get; set; } = null!;

    public virtual Trabajador? Trabajador { get; set; }
}
