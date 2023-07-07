using Projeto.Dominio;

namespace Projeto.Aplicacao.Servicos
{
    public class PontuaFamilia : IPontuaFamilia
    {
        private readonly IFamiliaRepositorio _familiaRepositorio;
        private readonly Criterios validacoes;
        private readonly List<IValidaCriteriosAtendidos> criterios = new()
        {
            new CriterioQuantidadeDeDependentes(),
            new CriterioRenda(),
        };
        public PontuaFamilia(IFamiliaRepositorio familiaRepositorio, Criterios criterios)
        {
            _familiaRepositorio = familiaRepositorio;
            validacoes = criterios;
        }

        public Familia PontuarFamiliaPelosCriteriosAtendidos()
        {
            Familia familiaRetornada = BuscarFamilia();
            validacoes.SetarCriterios(criterios);
            validacoes.Resultado(familiaRetornada);
            return familiaRetornada;
        }

        private Familia BuscarFamilia()
        {
            return _familiaRepositorio.BuscarTodos();
        }
    }
}
