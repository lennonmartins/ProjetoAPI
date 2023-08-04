namespace Projeto.Dominio
{
    public interface RepositorioBase <T> where T : class
    {
        void Salvar(T entidade);
        void Atualizar(T entidade);
        void Deletar(T entidade);
        IEnumerable<T> ObterTodas();
        T ObterPor(int id);
    }
}
