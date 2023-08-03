using Projeto.Dominio.Familias;
using Projeto.Dominio.Pontuacoes;

namespace Projeto.Aplicacao.ServicoDePontuacao
{
    public class PontuaFamilia : IPontuaFamilia
    {
        private readonly ValidacaoDeCriteriosAtendidos _validacaoDeCriterios;  
        private readonly IFamiliaRepositorio _familiaRepositorio;
        
        public PontuaFamilia(ValidacaoDeCriteriosAtendidos validacao, IFamiliaRepositorio familiaRepositorio)
        {
            _validacaoDeCriterios = validacao;
            _familiaRepositorio = familiaRepositorio;
        }

        public Familia PontuarPelosCriteriosAtendidos(Familia familia)
        {
            var pontos = _validacaoDeCriterios.ObterQuantidadeDePontos(familia);
            var pontuacao = new Pontuacao();
            pontuacao.AdicionarPontos(pontos);
            familia.AdiconarPontucao(pontuacao);
            _familiaRepositorio.Atualizar(familia);
            return familia;
        }
    }
} 
