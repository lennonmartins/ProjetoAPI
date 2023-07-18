using Projeto.Aplicacao.ServicoDePontuacao;
using Projeto.Dominio;

namespace Projeto.Aplicacao.Familias
{
    public class ObterFamilia : IObterFamilia
    {
        private readonly IFamiliaRepositorio _familiaRepositorio;
        private IPontuaFamilia _pontuaFamilia;
        public ObterFamilia(IFamiliaRepositorio familiaRepositorio, IPontuaFamilia pontuaFamilia) 
        {
            _familiaRepositorio = familiaRepositorio;    
            _pontuaFamilia = pontuaFamilia;
        }
        public Familia ObterResponsavelPeloCpf(string cpfDoResponsavel)
        {
            var familiaRetornada = _familiaRepositorio.ObterPeloCpfDoResponsavel(cpfDoResponsavel);
            _pontuaFamilia.PontuarPelosCriteriosAtendidos(familiaRetornada);
            return familiaRetornada;
        }
    }
}
