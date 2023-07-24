using Projeto.Dominio;

namespace Projeto.Aplicacao.ServicoDePontuacao
{
    public interface IPontuaFamilia
    {
        public Familia PontuarPelosCriteriosAtendidos(Familia familia, Pontuacao pontuacao);
    }
}
