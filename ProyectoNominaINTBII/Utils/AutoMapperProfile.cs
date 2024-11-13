using AutoMapper;
using ProyectoNominaINTBII.Models;
using ProyectoNominaINTBII.DTOS;

namespace ProyectoNominaINTBII.Utils
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<AreaGeografica, AreaGeograficaDTO>();
            CreateMap<BaseCotizacion, BaseCotizacionDTO>();
            CreateMap<Categorium, CategoriumDTO>();
            CreateMap<Departamento, DepartamentoDTO>();
            CreateMap<Empresa, EmpresaDTO>();
            CreateMap<EmpresaRegPat, EmpresaRegPatDTO>();
            CreateMap<EstadoCivil, EstadoCivilDTO>();
            CreateMap<MotivoNoTimbrar, MotivoNoTimbrarDTO>();
            CreateMap<Puesto, PuestoDTO>();
            CreateMap<SatBanco, SatBancoDTO>();
            CreateMap<SatEstado, SatEstadoDTO>();
            CreateMap<SatFormaPago, SatFormaPagoDTO>();
            CreateMap<SatMonedum, SatMonedumDTO>();
            CreateMap<SatMunicipio, SatMunicipioDTO>();
            CreateMap<SatOrigenRecurso, SatOrigenRecursoDTO>();
            CreateMap<SatPai, SatPaiDTO>();
            CreateMap<SatPeriocidadPago, SatPeriocidadPagoDTO>();
            CreateMap<SatRegimenFiscal, SatRegimenFiscalDTO>();
            CreateMap<SatRiesgoPuesto, SatRiesgoPuestoDTO>();
            CreateMap<SatTipoContrato, SatTipoContratoDTO>();
            CreateMap<SatTipoHora, SatTipoHoraDTO>();
            CreateMap<SatTipoJornadum, SatTipoJornadumDTO>();
            CreateMap<SatTipoRegiman, SatTipoRegimanDTO>();
            CreateMap<Sexo, SexoDTO>();
            CreateMap<TipoConstitucion, TipoConstitucionDTO>();
            CreateMap<TipoEmpleado, TipoEmpleadoDTO>();
            CreateMap<TipoEmpresa, TipoEmpresaDTO>();
            CreateMap<Trabajador, TrabajadorDTO>();



        }
    }
}
