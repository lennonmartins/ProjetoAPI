using Projeto.Dominio.Familias;
using Projeto.Dominio.Pontuacoes;

namespace Projeto.Aplicacao.ServicoDePontuacao
{
    public class PontuaFamilia : IPontuaFamilia
    {
        private readonly CalculaPontosPorCriterios _validacaoDeCriterios;  
        private readonly IFamiliaRepositorio _familiaRepositorio;
        
        public PontuaFamilia(CalculaPontosPorCriterios validacao, IFamiliaRepositorio familiaRepositorio)
        {
            _validacaoDeCriterios = validacao;
            _familiaRepositorio = familiaRepositorio;
        }

        public Familia PontuarPelosCriteriosAtendidos(Familia familia)
        {
            var pontos = _validacaoDeCriterios.CalcularQuantidadeDePontos(familia);
            var pontuacao = new Pontuacao(pontos);
            familia.AdiconarPontucao(pontuacao);
            _familiaRepositorio.Atualizar(familia);
            return familia;
        }
    }
} 
