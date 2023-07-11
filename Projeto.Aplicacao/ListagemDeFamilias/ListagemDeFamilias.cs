using Projeto.Aplicacao.DTOs.Responses;
using Projeto.Aplicacao.ServicoDePontuacao;
using Projeto.Dominio;

namespace Projeto.Aplicacao.ListagemDeFamilias
{
    public class ListagemDeFamilias : IListagemDeFamilias
    {
        private readonly IFamiliaRepositorio _familiaRepositorio;
        
        private readonly IPontuaFamilia _pontuaFamilia;

        public ListagemDeFamilias(IFamiliaRepositorio familiaRepositorio, IPontuaFamilia pontuaFamilia)
        {
            _familiaRepositorio = familiaRepositorio;
            _pontuaFamilia = pontuaFamilia;
        }

        public List<FamiliaPontuadaResponseDto> ObterListaOrdenadaPorPontos()
        {
            var familiasRetornadas = _familiaRepositorio.ObterTodas();
            var familiasOrdenadasPorPontos  = OrdernarPelaPontuacao(familiasRetornadas);
            return familiasOrdenadasPorPontos;
        }

        private List<FamiliaPontuadaResponseDto> OrdernarPelaPontuacao(List<Familia> familias)
        { 
            var familiasPontuadas = new List<FamiliaPontuadaResponseDto>();

            foreach (var familia in familias)
            {
                familiasPontuadas.Add(_pontuaFamilia.PontuarPelosCriteriosAtendidos(familia.Cpf_responsavel));
            }

            var familiaPontuadasEOrdenadas = familiasPontuadas.OrderByDescending(f => f.Pontos).ToList();
            return familiaPontuadasEOrdenadas;
        }
    }
}
