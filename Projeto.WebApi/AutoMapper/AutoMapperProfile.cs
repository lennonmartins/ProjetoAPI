using AutoMapper;
using Projeto.Aplicacao.DTOs;
using Projeto.Dominio;

namespace Projeto.WebApi.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            CreateMap<FamiliaRequestDto, Familia>();
            CreateMap<Familia, FamiliaPontuadaResponseDto>();
        }
    }
}
