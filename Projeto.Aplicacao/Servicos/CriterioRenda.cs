using Projeto.Dominio;

namespace Projeto.Aplicacao.Servicos
{
    public class CriterioRenda : IValidaCriteriosAtendidos
    {
        public void ValidarCriteriosAtendidos(Familia familia)
        {
            if (familia.RendaTotalDaFamilia > 900 && familia.RendaTotalDaFamilia <= 1500)
            {
                familia.AdicionarPontos(3);
            }
            if (familia.RendaTotalDaFamilia <= 900)
            {
                familia.AdicionarPontos(5);
            }
        }
    }
}
