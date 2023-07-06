using Projeto.Dominio;

namespace Projeto.Aplicacao.Servicos
{
    public class PontuaFamilia
    {
        private readonly Criterios validacoes;
        private readonly IFamiliaRepositorio _familiaRepositorio;
        private readonly List<IValidaCriteriosAtendidos> criterios = new()
        {
            new CriterioQuantidadeDeDependentes(),
            new CriterioRenda(),
        };

        public Familia PontuarFamiliaPelosCriteriosAtendidos()
        {
            Familia familiaRetornada = buscarFamilia();
            validacoes.setarCriterios(criterios);
            validacoes.resultado(familiaRetornada);
            return familiaRetornada;
        }

        private Familia buscarFamilia()
        {
            return _familiaRepositorio.BuscarTodos() as Familia;
        }
    }
}
