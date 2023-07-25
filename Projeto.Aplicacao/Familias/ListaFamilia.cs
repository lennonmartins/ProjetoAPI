using Projeto.Aplicacao.DTOs.Responses;
using Projeto.Aplicacao.ServicoDePontuacao;
using Projeto.Dominio.Familias;

namespace Projeto.Aplicacao.Familias
{
    public class ListaFamilia : IListaFamilia
    {
        private readonly IFamiliaRepositorio _familiaRepositorio;
        private readonly IObtemFamilia _obtemFamilia;
        private readonly IPontuaFamilia _pontuaFamilia;

        public ListaFamilia(IFamiliaRepositorio familiaRepositorio, IPontuaFamilia pontuaFamilia, IObtemFamilia obtemFamilia)
        {
            _familiaRepositorio = familiaRepositorio;
            _pontuaFamilia = pontuaFamilia;
            _obtemFamilia = obtemFamilia;
        }

        public List<FamiliaPontuadaResponseDto> ObterListaOrdenadaPorPontos()
        {
            var familiasRetornadas = _familiaRepositorio.ObterTodas();
            var familiasOrdenadasPorPontos = OrdernarPelaPontuacao(familiasRetornadas);
            return familiasOrdenadasPorPontos;
        }

        private List<FamiliaPontuadaResponseDto> OrdernarPelaPontuacao(List<Familia> familias)
        {
            var familiasPontuadas = new List<FamiliaPontuadaResponseDto>();

            foreach (var familia in familias)
            {
                familiasPontuadas.Add(_obtemFamilia.ObterResponsavelPeloCpf(familia.Cpf_responsavel));
            }

            var familiaPontuadasEOrdenadas = familiasPontuadas.OrderByDescending(f => f.Pontos).ToList();
            return familiaPontuadasEOrdenadas;
        }
    }
}
