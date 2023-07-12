namespace Projeto.Aplicacao.Pontuacoes
{
    public class FabricaDeCriterios
    {
        private readonly List<IValidaCriteriosAtendidos> _criterios;

        public FabricaDeCriterios()
        {
            _criterios = new List<IValidaCriteriosAtendidos>
            {
                new CriterioQuantidadeDeDependentes(),
                new CriterioRenda()
            };
        }

        public List<IValidaCriteriosAtendidos> Fabricar()
        {
            return _criterios.ToList();
        }
    }
}
