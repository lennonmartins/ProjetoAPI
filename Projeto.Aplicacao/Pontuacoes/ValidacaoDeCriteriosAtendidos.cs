using Projeto.Dominio.Familias;
using Projeto.Dominio.Pontuacoes;

namespace Projeto.Aplicacao.ServicoDePontuacao
{
    public class ValidacaoDeCriteriosAtendidos
    {
       private readonly GerenciadorDeCriterios _criterios;
       
       public ValidacaoDeCriteriosAtendidos(GerenciadorDeCriterios criterios)
        {
            _criterios = criterios;
        }

        public Familia ObterQuantidadeDePontos(Familia familia)
        {
            int pontos = 0;
            var pontuacao = new Pontuacao(pontos);
            var criterios = _criterios.ObterCriterioSetados();
            foreach ( var criterio in criterios)
            {
              pontos +=  criterio.ValidarCriteriosAtendidos(familia);
            }
            pontuacao.AdicionarPontos(pontos);
            familia.AdiconarPontucao(pontuacao);
            //salvar atualização em fmailia;
            return familia;
        }
    }
}
