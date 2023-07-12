using Projeto.Dominio.Familias;

namespace Projeto.Aplicacao.Pontuacoes
{
    public class ValidacaoDeCriteriosAtendidos
    {
       private readonly FabricaDeCriterios fabricaDeCriterios;
       
       public ValidacaoDeCriteriosAtendidos(FabricaDeCriterios fabricaDeCriterios)
        {
            fabricaDeCriterios = fabricaDeCriterios;
        }

        public Familia ObterQuantidadeDePontosPorCriteriosAtendidos(Familia familia)
        {
            var criterios = fabricaDeCriterios.Fabricar();
            foreach ( var criterio in criterios)
            {
                criterio.ValidarCriteriosAtendidos(familia);
            }

            return familia;
        }
    }
}
