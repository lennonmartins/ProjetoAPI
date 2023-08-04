using NHibernate;

namespace Projeto.Infra
{
    public abstract class RepositorioBaseNh <T> where T : class 
    {
        protected readonly ISession _session;

        protected RepositorioBaseNh(ISession session)
        {
            _session = session;
        }

        public void Deletar(T entidade)
        {
            _session.Delete(entidade);
        }

        public T ObterPor(int id) 
        { 
            return _session.Get<T>(id);
        }
    }
}
