namespace Projeto.Dominio.Familias
{
    public interface IFamiliaRepositorio
    {
        void SalvarNova(Familia familia);
        Familia ObterPeloCpfDoResponsavel(string cpf);
        List<Familia> ObterTodas();
    }
}
