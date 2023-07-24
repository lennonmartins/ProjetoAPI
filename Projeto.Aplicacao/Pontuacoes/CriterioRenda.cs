using Projeto.Dominio;

namespace Projeto.Aplicacao.ServicoDePontuacao
{
    public class CriterioRenda : IValidaCriteriosAtendidos
    {
        private readonly int RendaMaxima = 1500;
        private readonly int RendaMinima = 900;
        public void ValidarCriteriosAtendidos(Familia familia, Pontuacao pontuacao)
        {
            int pontos = 0;
            if (familia.RendaTotalDaFamilia > RendaMinima && familia.RendaTotalDaFamilia <= RendaMaxima)
            {
                pontos = 3;   
            }
            if (familia.RendaTotalDaFamilia <= RendaMinima)
            {
                pontos = 5;
            }
            pontuacao.AdicionarPontos(pontos);
        }
    }
}
