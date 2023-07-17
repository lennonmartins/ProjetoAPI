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

        public Familia ObterPeloCpfDoResponsavel(string cpf)
        {
            try
            {
                var familia = _session.Query<Familia>().Single(familia => familia.Cpf_responsavel == cpf);
                if (familia == null)
                {
                    throw new Exception("familia não encontrada");
                }
                return familia;
            }
            catch(InvalidOperationException e)
            {
                throw;
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
