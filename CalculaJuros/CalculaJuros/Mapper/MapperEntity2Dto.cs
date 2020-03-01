using AutoMapper;
using CalculaJuros.CrossCutting.DTO.Calculo;
using CalculaJuros.Domain;

namespace CalculaJuros.Api.Mapper
{
    public class MapperEntity2Dto : Profile
    {
        public MapperEntity2Dto()
        {
            CreateMap<Calculo, CalculoDTO>()
            .AfterMap((src, dest) => dest.Value = src.Value.ToString("N2"));
        }
    }
}