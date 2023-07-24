using Projeto.Dominio;

namespace Projeto.Aplicacao.ServicoDePontuacao
{
    public class CriterioQuantidadeDeDependentes : IValidaCriteriosAtendidos
    {
        private readonly int MaximoDeDependentes = 3;
        private readonly int MinimoDeDependentes = 1;
        public void ValidarCriteriosAtendidos(Familia familia, Pontuacao pontuacao)
        {
            int pontos = 0;
            if (familia.QuantidadeDeDependentes >= MaximoDeDependentes)
            {
                pontos = 3;
            }
            if (familia.QuantidadeDeDependentes >= MinimoDeDependentes)
            {
                pontos = 2;
            }
            pontuacao.AdicionarPontos(pontos);
        }
    }
}
