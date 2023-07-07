using Projeto.Dominio;

namespace Projeto.Aplicacao.Servicos
{
    public class CriterioQuantidadeDeDependentes : IValidaCriteriosAtendidos
    {
        public void ValidarCriteriosAtendidos(Familia familia)
        {
            if (familia.QuantidadeDeDependentes >= 3 )
            {
                familia.AdicionarPontos(3);
            }
            if (familia.QuantidadeDeDependentes >= 1)
            {
                familia.AdicionarPontos(2);
            }
        }
    }
}
