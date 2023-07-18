using Projeto.Aplicacao.DTOs.Responses;

namespace Projeto.Aplicacao.Familias
{
    public interface IListaFamilia
    {
        List<FamiliaPontuadaResponseDto> ObterListaOrdenadaPorPontos();
    }
}
