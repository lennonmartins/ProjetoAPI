using Projeto.Aplicacao.DTOs;
using Projeto.Dominio;

namespace Projeto.Aplicacao.Servicos
{
    public interface IPontuaFamilia
    {
        public FamiliaPontuadaResponseDto PontuarFamiliaPelosCriteriosAtendidos(string cpf);
    }
}
