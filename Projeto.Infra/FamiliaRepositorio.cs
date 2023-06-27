using NHibernate;
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
        public void Salvar(Familia familia)
        {
            using (var transacao = _session.BeginTransaction())
            try
            {
                _session.Save(familia);
                transacao.Commit();
            }
            catch
            {
                transacao.Rollback();
                throw new NotImplementedException();
            }
        }
    }
}
