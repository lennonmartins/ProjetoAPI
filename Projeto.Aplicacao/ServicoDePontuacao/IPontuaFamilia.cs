using Projeto.Aplicacao.DTOs;
using Projeto.Dominio;

namespace Projeto.Aplicacao.ServicoDePontuacao
{
    public interface IPontuaFamilia
    {
        public FamiliaPontuadaResponseDto PontuarFamiliaPelosCriteriosAtendidos(string cpf);
    }
}
