namespace Projeto.Dominio
{
    public interface IFamiliaRepositorio
    {
        void Salvar(Familia familia);
        IEnumerable<Familia> BuscarTodos();
       
    }
}
