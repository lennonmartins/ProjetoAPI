using AutoMapper;
using Projeto.Aplicacao.DTOs.Requests;
using Projeto.Dominio.Familias;

namespace Projeto.Aplicacao.Familias
{
    public  class AtualizaFamilia
    {
        private readonly IFamiliaRepositorio _familiaRepositorio;
        private readonly IMapper _mapper;
        public AtualizaFamilia(IFamiliaRepositorio familiaRepositorio, IMapper mapper) 
        {
            _mapper = mapper;   
            _familiaRepositorio = familiaRepositorio;
        }
        public Familia Atualizar(FamiliaRequestDto familiaRequest, int id)
        {
            var familiaParaAlterar = _familiaRepositorio.ObterPor(id);
            var familiaMapeada = _mapper.Map<Familia>(familiaRequest);
            familiaParaAlterar.AlterarFamilia(familiaMapeada);        
            _familiaRepositorio.Atualizar(familiaParaAlterar);
            return familiaParaAlterar;
        }
    }
}
