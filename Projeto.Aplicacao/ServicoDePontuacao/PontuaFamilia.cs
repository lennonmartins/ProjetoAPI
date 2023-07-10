using AutoMapper;
using Projeto.Aplicacao.DTOs.Responses;
using Projeto.Dominio;

namespace Projeto.Aplicacao.ServicoDePontuacao
{
    public class PontuaFamilia : IPontuaFamilia
    {
        private readonly IFamiliaRepositorio _familiaRepositorio;
        private readonly ValidacaoDeCriteriosAtendidos _validacaoDeCriterios;
        private readonly IMapper _mapper;
    
        public PontuaFamilia(IFamiliaRepositorio familiaRepositorio, ValidacaoDeCriteriosAtendidos validacao, IMapper mapper)
        {
            _familiaRepositorio = familiaRepositorio;
            _validacaoDeCriterios = validacao;
            _mapper = mapper;
        }

        public FamiliaPontuadaResponseDto PontuarFamiliaPelosCriteriosAtendidos(string cpfDoReponsavel)
        {
            Familia familiaRetornada = BuscarFamiliaPeloCpfDoResponsavel(cpfDoReponsavel);
            _validacaoDeCriterios.ObterQuantidadeDePontosPorCriteriosAtendidos(familiaRetornada);
            var familiaPontuada = _mapper.Map<FamiliaPontuadaResponseDto>(familiaRetornada);
            return familiaPontuada;
        }

        private Familia BuscarFamiliaPeloCpfDoResponsavel(string cpfDoReponsavel)
        {
            return _familiaRepositorio.BuscarFamiliaPeloCpfDoResponsavel(cpfDoReponsavel);
        }
    }
}
