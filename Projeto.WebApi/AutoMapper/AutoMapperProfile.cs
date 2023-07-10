using AutoMapper;
using Projeto.Aplicacao.DTOs.Requests;
using Projeto.Aplicacao.DTOs.Responses;
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
