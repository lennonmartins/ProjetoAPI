using NHibernate;
using NHibernate.Util;
using Projeto.Dominio;
using Projeto.Dominio.Familias;

namespace Projeto.Infra
{
    public class FamiliaRepositorio : IFamiliaRepositorio
    {
        private readonly ISession _session;

        public FamiliaRepositorio(ISession session)
        {
            _session = session;
        }

        public Familia? ObterPeloCpfDoResponsavel(string cpf)
        {
            try
            {
                return _session.Query<Familia>().FirstOrDefault(familia => familia.Cpf_responsavel == cpf);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public List<Familia> ObterTodas()
        {
            try
            {
               return _session.Query<Familia>().ToList();
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public void SalvarNova(Familia familia)
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
