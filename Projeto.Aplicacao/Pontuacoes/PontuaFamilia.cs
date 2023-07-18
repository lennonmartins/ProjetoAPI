using AutoMapper;
using Projeto.Aplicacao.DTOs.Responses;
using Projeto.Aplicacao.Familias;
using Projeto.Dominio;

namespace Projeto.Aplicacao.ServicoDePontuacao
{
    public class PontuaFamilia : IPontuaFamilia
    {
        private readonly IFamiliaRepositorio _familiaRepositorio;
        private readonly ValidacaoDeCriteriosAtendidos _validacaoDeCriterios;
        private readonly IObterFamilia _obterFamilia;
        private readonly IMapper _mapper;
    
        public PontuaFamilia(IFamiliaRepositorio familiaRepositorio, ValidacaoDeCriteriosAtendidos validacao, IObterFamilia obterFamilia, IMapper mapper)
        {
            _familiaRepositorio = familiaRepositorio;
            _validacaoDeCriterios = validacao;
            _obterFamilia = obterFamilia;
            _mapper = mapper;
        }

        public FamiliaPontuadaResponseDto PontuarPelosCriteriosAtendidos(Familia familia)
        {
            _validacaoDeCriterios.ObterQuantidadeDePontos(familia);
            var familiaPontuada = _mapper.Map<FamiliaPontuadaResponseDto>(familia);
            return familiaPontuada;
        }
    }
} 
