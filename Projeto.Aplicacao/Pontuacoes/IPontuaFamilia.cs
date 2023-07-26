using Projeto.Aplicacao.DTOs.Responses;
using Projeto.Dominio.Familias;
using Projeto.Dominio.Pontuacoes;

namespace Projeto.Aplicacao.ServicoDePontuacao
{
    public interface IPontuaFamilia
    {
        public Familia PontuarPelosCriteriosAtendidos(Familia familia);
    }
}
