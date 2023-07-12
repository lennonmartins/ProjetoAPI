using AutoMapper;
using Projeto.Aplicacao.DTOs.Responses;
using Projeto.Dominio.Familias;

namespace Projeto.Aplicacao.Pontuacoes
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

        public FamiliaPontuadaResponseDto PontuarPelosCriteriosAtendidos(string cpfDoReponsavel)
        {
            var familia = _familiaRepositorio.ObterPeloCpfDoResponsavel(cpfDoReponsavel);
            return _mapper.Map<FamiliaPontuadaResponseDto>(
                _validacaoDeCriterios.ObterQuantidadeDePontosPorCriteriosAtendidos(familia));
        }
    }
}
