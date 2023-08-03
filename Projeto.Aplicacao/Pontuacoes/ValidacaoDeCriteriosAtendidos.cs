using Projeto.Dominio.Familias;

namespace Projeto.Aplicacao.ServicoDePontuacao
{
    public class ValidacaoDeCriteriosAtendidos
    {
       private readonly GerenciadorDeCriterios _criterios;
       
       public ValidacaoDeCriteriosAtendidos(GerenciadorDeCriterios criterios)
        {
            _criterios = criterios;
        }

        public int ObterQuantidadeDePontos(Familia familia)
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
