using NHibernate;
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

        public Familia ObterPeloCpfDoResponsavel(string cpf)
        {
            try
            {
                var familia = _session.Query<Familia>().Single(familia => familia.Cpf_responsavel == cpf);
                
                return familia ?? throw new Exception("Familia não encontrada");
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
            catch(Exception)
            {
                throw;
            }
        }

        public void CadastrarNova(Familia familia)
        {
            using var transacao = _session.BeginTransaction();
            try
            {
                _session.Save(familia);
                transacao.Commit();
            }
            catch (Exception ex)
            {
                transacao.Rollback();
                throw;
            }
        }

        public void Atualizar(Familia familia)
        {
            using var transacao = _session.BeginTransaction();
            try
            {
                _session.Update(familia);
                transacao.Commit();
            }
            catch
            {
                transacao.Rollback();
                throw;
            }
        }
    }
}
