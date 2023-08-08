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

        public void Remover(T entidade)
        {
            using var transacao = _session.BeginTransaction();
            try
            {
                _session.Delete(entidade);
                transacao.Commit();
            }
            catch(Exception) 
            {
                throw;
            }
        }

        public T ObterPor(int id) 
        { 
            return _session.Get<T>(id);
        }

        public IEnumerable<T> ObterTodas()
        {
            try
            {
                return _session.Query<T>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Atualizar(T entidade)
        {
            using var transacao = _session.BeginTransaction();
            try
            {
                _session.SaveOrUpdate(entidade);
                transacao.Commit();
            }
            catch
            {
                transacao.Rollback();
                throw;
            }
        }

        public void Salvar(T entidade)
        {
            using var transacao = _session.BeginTransaction();
            try
            {
                _session.Save(entidade);
                transacao.Commit();
            }
            catch (Exception ex)
            {
                transacao.Rollback();
                throw;
            }
        }
    }
}
