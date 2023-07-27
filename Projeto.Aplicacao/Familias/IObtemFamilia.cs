using Projeto.Aplicacao.DTOs.Responses;

namespace Projeto.Aplicacao.Familias
{
    public interface IObtemFamilia
    {
        FamiliaPontuadaResponseDto  ObterComPontuacaoPeloCpfDoResponsavel(string cpfDoResponsavel);
    }
}
