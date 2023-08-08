using Projeto.Dominio.Familias;

namespace Projeto.Aplicacao.ServicoDePontuacao
{
    public class CalculaPontosPorCriterios
    {
       private readonly GerenciadorDeCriterios _criterios;
       
       public CalculaPontosPorCriterios(GerenciadorDeCriterios criterios)
        {
            _criterios = criterios;
        }

        public int CalcularQuantidadeDePontos(Familia familia)
        {
            int pontos = 0;
            var criterios = _criterios.ObterCriterioSetados();
            foreach ( var criterio in criterios)
            {
              pontos += criterio.ValidarCriteriosAtendidos(familia);
            }
            return pontos;
        }
    }
}
