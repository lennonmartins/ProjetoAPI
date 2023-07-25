using Projeto.Aplicacao.DTOs.Responses;
using Projeto.Dominio.Familias;

namespace Projeto.Aplicacao.ServicoDePontuacao
{
    public interface IPontuaFamilia
    {
        public Familia PontuarPelosCriteriosAtendidos(Familia familia);
    }
}
