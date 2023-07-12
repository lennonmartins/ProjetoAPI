using Projeto.Aplicacao.DTOs.Responses;

namespace Projeto.Aplicacao.Pontuacoes
{
    public interface IPontuaFamilia
    {
        public FamiliaPontuadaResponseDto PontuarPelosCriteriosAtendidos(string cpf);
    }
}
