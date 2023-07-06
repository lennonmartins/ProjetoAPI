using AutoMapper;
using Projeto.Aplicacao.DTOs;
using Projeto.Dominio;

namespace Projeto.Aplicacao.RegistroFamilia
{
    public class CadastraFamiliaService : ICadastraFamilia
    {  
        private readonly IFamiliaRepositorio _familiaRepositorio;
        private readonly IMapper _mapper;
        public CadastraFamiliaService(IFamiliaRepositorio familiaRepositorio, IMapper mapper)
        {
            _familiaRepositorio = familiaRepositorio;
            _mapper = mapper;
        }
        public Familia Cadastrarfamilia(FamiliaRequestDto familiaRequestDto)
        {
            var familia = _mapper.Map<Familia>(familiaRequestDto);
            _familiaRepositorio.Salvar(familia);
            return familia;
        }
    }
}
