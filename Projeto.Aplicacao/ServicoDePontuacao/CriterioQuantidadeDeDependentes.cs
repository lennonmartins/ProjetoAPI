using Projeto.Dominio;

namespace Projeto.Aplicacao.ServicoDePontuacao
{
    public class CriterioQuantidadeDeDependentes : IValidaCriteriosAtendidos
    {
        public void ValidarCriteriosAtendidos(Familia familia)
        {
            int pontos = 0;
            if (familia.QuantidadeDeDependentes >= 3 )
            {
                pontos = 3;
            }
            if (familia.QuantidadeDeDependentes >= 1)
            {
                pontos = 2;
            }
            familia.AdicionarPontos(pontos);
        }
    }
}
