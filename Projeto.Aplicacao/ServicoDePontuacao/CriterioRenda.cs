using Projeto.Dominio;

namespace Projeto.Aplicacao.ServicoDePontuacao
{
    public class CriterioRenda : IValidaCriteriosAtendidos
    {
        public void ValidarCriteriosAtendidos(Familia familia)
        {
            int pontos = 0;
            if (familia.PossuiRendaEntreMininaEMaxima())
            {
                pontos = 3;   
            }
            if (familia.PossuiRendaMenorQueAMinina())
            {
                pontos = 5;
            }
            familia.AdicionarPontos(pontos);
        }
    }
}
