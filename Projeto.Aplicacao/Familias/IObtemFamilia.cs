using Projeto.Aplicacao.DTOs.Responses;
using Projeto.Dominio;

namespace Projeto.Aplicacao.Familias
{
    public interface IObtemFamilia
    {
        FamiliaPontuadaResponseDto  ObterResponsavelPeloCpf(string cpfDoResponsavel);
    }
}
