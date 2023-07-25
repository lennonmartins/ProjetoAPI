using Projeto.Dominio.Familias;

namespace Projeto.Aplicacao.ServicoDePontuacao
{
    public class CriterioRenda : IValidaCriteriosAtendidos
    {
        private readonly int RendaMaxima = 1500;
        private readonly int RendaMinima = 900;
        public void ValidarCriteriosAtendidos(Familia familia)
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
            
        }
    }
}
