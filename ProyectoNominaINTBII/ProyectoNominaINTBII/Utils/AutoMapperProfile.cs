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
        }
    }
}
