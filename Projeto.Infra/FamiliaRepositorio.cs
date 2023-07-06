using NHibernate;
using NHibernate.Util;
using Projeto.Dominio;

namespace Projeto.Infra
{
    public class FamiliaRepositorio : IFamiliaRepositorio
    {
        private readonly ISession _session;

        public FamiliaRepositorio(ISession session)
        {
            _session = session;
        }

        public IEnumerable<Familia> BuscarTodos()
        {
            yield return _session.Query<Familia>().First();
        }

        public void Salvar(Familia familia)
        {
            using (var transacao = _session.BeginTransaction())
            try
            {
                _session.Save(familia);
                transacao.Commit();
            }
            catch(Exception ex)
            {
                transacao.Rollback();
                throw ;
            }
        }
    }
}
