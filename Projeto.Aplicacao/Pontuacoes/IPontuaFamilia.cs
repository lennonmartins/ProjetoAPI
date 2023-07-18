using Projeto.Aplicacao.DTOs.Responses;
using Projeto.Dominio;

namespace Projeto.Aplicacao.ServicoDePontuacao
{
    public interface IPontuaFamilia
    {
        public FamiliaPontuadaResponseDto PontuarPelosCriteriosAtendidos(Familia familia);
    }
}
