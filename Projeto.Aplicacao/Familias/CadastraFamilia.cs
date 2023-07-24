using AutoMapper;
using Projeto.Aplicacao.DTOs.Requests;
using Projeto.Dominio;

namespace Projeto.Aplicacao.Familias
{
    public class CadastraFamilia : ICadastraFamilia
    {
        private readonly IFamiliaRepositorio _familiaRepositorio;
        private readonly IMapper _mapper;

        public CadastraFamilia(IFamiliaRepositorio familiaRepositorio, IMapper mapper)
        {
            _familiaRepositorio = familiaRepositorio;
            _mapper = mapper;
        }
        public Familia Cadastrar(FamiliaRequestDto familiaRequestDto)
        {
            var familia = _mapper.Map<Familia>(familiaRequestDto);
            _familiaRepositorio.CadastrarNova(familia);
            return familia;
        }
    }
}
