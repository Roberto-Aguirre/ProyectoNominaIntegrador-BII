public class SatFormaPago
{
    public int Id { get; set; }
    public string ClaveSAT { get; set; }
    public string DescripcionSAT { get; set; }
    public string BancarizadoSAT { get; set; }
    public string Tipo { get; set; }
    public DateTime FechaInicioVigenciaSAT { get; set; }
    public DateTime FechaFinVigenciaSAT { get; set; }
    public char Estatus { get; set; }
}

public class SatMoneda
{
    public int Id { get; set; }
    public string ClaveSAT { get; set; }
    public string DescripcionSAT { get; set; }
    public int DecimalesSAT { get; set; }
    public int PorcentajeVariacionSAT { get; set; }
    public DateTime FechaInicioVariacionSAT { get; set; }
    public DateTime FechaFinVariacionSAT { get; set; }
    public char Estatus { get; set; }
}

public class SatMunicipios
{
    public int Id { get; set; }
    public int Estado { get; set; }
    public string ClaveSAT { get; set; }
    public string DescripcionSAT { get; set; }
    public DateTime FechaInicioVigenciaSAT { get; set; }
    public DateTime FechaFinVigenciaSAT { get; set; }
    public char Estatus { get; set; }
}

public class SatOrigenRecursos
{
    public int Id { get; set; }
    public string OrigenRecursosSAT { get; set; }
    public string DescripcionSAT { get; set; }
    public char Estatus { get; set; }
}
public class SatPais
{
    public int Id { get; set; }
    public string ClaveSAT { get; set; }
    public string DescripcionSAT { get; set; }
    public string FmtoCodPostalSAT { get; set; }
    public string FmtoRegIdenTribSAT { get; set; }
    public string ValidaRegIdenTribSAT { get; set; }
    public string AgrupacionesSAT { get; set; }
    public char Estatus { get; set; }
}
public class SatPeriocidadPago
{
    public int Id { get; set; }
    public string ClaveSAT { get; set; }
    public string DescripcionSAT { get; set; }
    public DateTime FechaInicioVigenciaSAT { get; set; }
    public DateTime FechaFinVigenciaSAT { get; set; }
    public int Dias { get; set; }
    public string DiasValidos { get; set; }
    public char Estatus { get; set; }
}
public class SatRegimenFiscal
{
    public int Id { get; set; }
    public string ClaveSAT { get; set; }
    public string DescripcionSAT { get; set; }
    public DateTime FechaInicioVigenciaSAT { get; set; }
    public DateTime FechaFinVigenciaSAT { get; set; }
    public int Dias { get; set; }
    public string DiasValidos { get; set; }
    public char Estatus { get; set; }
}

public class SatRegimenFiscal
{
    public int Id { get; set; }
    public string ClaveSAT { get; set; }
    public string DescripcionSAT { get; set; }
    public string PersonaFisicaSAT { get; set; }
    public string PersonaMoralSAT { get; set; }
    public DateTime FechaInicioVigenciaSAT { get; set; }
    public DateTime FechaFinVigenciaSAT { get; set; }
    public char Estatus { get; set; }
}

public class SatRiesgoPuesto
{
    public int Id { get; set; }
    public string ClaveSAT { get; set; }
    public string Descripcion { get; set; }
    public DateTime DechaInicioVigencia { get; set; }
    public DateTime DechaFinVigencia { get; set; }
    public char Estatus { get; set; }
}

public class SatTipoContrato
{
    public int Id { get; set; }
    public string ClaveSAT { get; set; }
    public string Descipcion { get; set; }
    public char Estatus { get; set; }
}

public class SatTipoHoras
{
    public int Id { get; set; }
    public string ClaveSAT { get; set; }
    public string DescripcionSAT { get; set; }
    public double Monto { get; set; }
    public char Estatus { get; set; }
}
public class SetTipoJornada
{
    public int Id { get; set; }
    public string ClaveSAT { get; set; }
    public string DescripcionSAT { get; set; }
    public double Horas { get; set; }
    public char Estatus { get; set; }
}
public class SetTipoRegimen
{
    public int Id { get; set; }
    public string ClaveSAT { get; set; }
    public string DescripcionSAT { get; set; }
    public DateTime FechaInicioVigenciaSAT { get; set; }
    public DateTime FechaFinVigenciaSAT { get; set; }
    public char Estatus { get; set; }
}
public class Sexo
{
    public int Id { get; set; }
    public string Descripcion { get; set; }
    public char Estatus { get; set; }
}
public class TipoConstitucion
{
    public int Id { get; set; }
    public string Descripcion { get; set; }
    public char Estatus { get; set; }
}
public class TipoEmpleado
{
    public int Id { get; set; }
    public string Descripcion { get; set; }
    public int Empresa {get;set;}
    public char Estatus { get; set; }
}
public class tipoEmpresa
{
    public int Id { get; set; }
    public string Descripcion { get; set; }
    public char Estatus { get; set; }
}

