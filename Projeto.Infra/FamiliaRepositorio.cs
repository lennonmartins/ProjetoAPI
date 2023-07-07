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

        public Familia BuscarTodos()
        {
             return _session.Query<Familia>().FirstOrDefault();
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
