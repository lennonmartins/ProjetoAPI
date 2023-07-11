using Projeto.Aplicacao.DTOs.Responses;

namespace Projeto.Aplicacao.ListagemDeFamilias
{
    public interface IListagemDeFamilias
    {
        List<FamiliaPontuadaResponseDto> ObterListaOrdenadaPorPontos();
    }
}
