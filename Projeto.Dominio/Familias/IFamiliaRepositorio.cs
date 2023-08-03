namespace Projeto.Dominio.Familias
{
    public interface IFamiliaRepositorio
    {
        void CadastrarNova(Familia familia);
        Familia ObterPeloCpfDoResponsavel(string cpf);
        List<Familia> ObterTodas();
        void Atualizar(Familia familia);
    }
}
