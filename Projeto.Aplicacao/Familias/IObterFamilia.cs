using Projeto.Dominio;

namespace Projeto.Aplicacao.Familias
{
    public interface IObterFamilia
    {
        Familia  ObterResponsavelPeloCpf(string cpfDoResponsavel);
    }
}
