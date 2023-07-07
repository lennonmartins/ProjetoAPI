namespace Projeto.Dominio
{
    public interface IFamiliaRepositorio
    {
        void Salvar(Familia familia);
        Familia BuscarTodos();
       
    }
}
