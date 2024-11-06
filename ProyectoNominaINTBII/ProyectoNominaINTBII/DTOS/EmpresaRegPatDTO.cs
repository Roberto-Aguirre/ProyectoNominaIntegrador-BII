using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoNominaINTBII.DTOS;

public partial class EmpresaRegPatDTO
{
    public int Id { get; set; }

    public int EmpresaId { get; set; }

    public int AreaGeograficaId { get; set; }

    public int RiesgoPuestoId { get; set; }

    public string? RegistroPatronal { get; set; }

    public string? LugarExpedicion { get; set; }

    public string? PathCertificadoSat { get; set; }

    public string? PathLlaveSat { get; set; }

    public string? PassSat { get; set; }

    public DateTime? VigenciaInicial { get; set; }

    public DateTime? VigenciaFinal { get; set; }

    public string? NumeroSerie { get; set; }

}
