using Projeto.Dominio;

namespace Projeto.Aplicacao.Servicos
{
    public class CriterioRenda : IValidaCriteriosAtendidos
    {
        public void ValidarCriteriosAtendidos(Familia familia)
        {
            int pontos = 0;
            if (familia.RendaTotalDaFamilia > 900 && familia.RendaTotalDaFamilia <= 1500)
            {
                pontos = 3;   
            }
            if (familia.RendaTotalDaFamilia <= 900)
            {
                pontos = 5;
            }
            familia.AdicionarPontos(pontos);
        }
    }
}
