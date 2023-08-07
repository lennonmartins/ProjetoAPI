using NHibernate;
using Projeto.Dominio.Familias;

namespace Projeto.Infra
{
    public class FamiliaRepositorio : RepositorioBaseNh<Familia>, IFamiliaRepositorio 
    {        
        public FamiliaRepositorio(ISession session) : base(session) { }

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

        public IEnumerable<Familia> ObterTodas()
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

        public void Atualizar(Familia familia)
        {
            using var transacao = _session.BeginTransaction();
            try
            {
                _session.UpdateAsync(familia);
                transacao.Commit();
            }
            catch
            {
                transacao.Rollback();
                throw;
            }
        }

        public void Salvar(Familia familia)
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
    }
}
