using Projeto.Dominio.Familias;
using Projeto.Dominio.Pontuacoes;

namespace Projeto.Aplicacao.ServicoDePontuacao
{
    public interface IValidaCriteriosAtendidos
    {
        int ValidarCriteriosAtendidos(Familia familia);
    }
}
