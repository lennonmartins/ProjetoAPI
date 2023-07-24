namespace Projeto.Dominio
{
    public interface IFamiliaRepositorio
    {
        void CadastrarNova(Familia familia);
        Familia ObterPeloCpfDoResponsavel(string cpf);
        List<Familia> ObterTodas();
    }
}
