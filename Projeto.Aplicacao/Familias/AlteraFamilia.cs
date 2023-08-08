using AutoMapper;
using Projeto.Aplicacao.DTOs.Requests;
using Projeto.Dominio.Familias;

namespace Projeto.Aplicacao.Familias
{
    public  class AlteraFamilia
    {
        private readonly IFamiliaRepositorio _familiaRepositorio;
        private readonly IMapper _mapper;
        public AlteraFamilia(IFamiliaRepositorio familiaRepositorio, IMapper mapper) 
        {
            _mapper = mapper;   
            _familiaRepositorio = familiaRepositorio;
        }
        public Familia Altera(FamiliaRequestDto familiaRequest, int id)
        {
            var familiaParaAlterar = _familiaRepositorio.ObterPor(id);
            var familiaMapeada = _mapper.Map<Familia>(familiaRequest);
            familiaParaAlterar.AlterarFamilia(familiaMapeada);        
            _familiaRepositorio.Atualizar(familiaParaAlterar);
            return familiaParaAlterar;
        }
    }
}
