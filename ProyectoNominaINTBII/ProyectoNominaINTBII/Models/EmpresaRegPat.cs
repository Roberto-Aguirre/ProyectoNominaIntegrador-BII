using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.Models;

public partial class EmpresaRegPat
{
    public int Id { get; set; }

    public int EmpresaId { get; set; }

    public int AreaGeograficaId { get; set; }

    public int RiesgoPuestoId { get; set; }

    public string RegistroPatronal { get; set; } = null!;

    public string LugarExpedicion { get; set; } = null!;

    public string? PathCertificadoSat { get; set; }

    public string? PathLlaveSat { get; set; }

    public string? PassSat { get; set; }

    public DateTime VigenciaInicial { get; set; }

    public DateTime VigenciaFinal { get; set; }

    public string NumeroSerie { get; set; } = null!;

    public virtual AreaGeografica AreaGeografica { get; set; } = null!;

    public virtual Empresa Empresa { get; set; } = null!;

    public virtual ICollection<InicioNomina> InicioNominas { get; set; } = new List<InicioNomina>();

    public virtual SatRiesgoPuesto RiesgoPuesto { get; set; } = null!;

    public virtual ICollection<Trabajador> Trabajadors { get; set; } = new List<Trabajador>();
}
