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
    }
}
