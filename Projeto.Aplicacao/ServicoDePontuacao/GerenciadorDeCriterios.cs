namespace Projeto.Aplicacao.ServicoDePontuacao
{
    public class GerenciadorDeCriterios
    {
        private readonly List<IValidaCriteriosAtendidos> _criterios;

        public GerenciadorDeCriterios()
        {
            _criterios = new List<IValidaCriteriosAtendidos>
            {
                new CriterioQuantidadeDeDependentes(),
                new CriterioRenda()
            };
        }

        public List<IValidaCriteriosAtendidos> ObterCriterioSetados()
        {
            return _criterios.ToList();
        }
    }
}
