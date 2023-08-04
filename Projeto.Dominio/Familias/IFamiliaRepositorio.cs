namespace Projeto.Dominio.Familias
{
    public interface IFamiliaRepositorio : RepositorioBase<Familia>
    {
        public Familia ObterPeloCpfDoResponsavel(string cpf);
    }
}
