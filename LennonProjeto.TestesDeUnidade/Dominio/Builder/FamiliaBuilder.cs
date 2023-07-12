using Projeto.Dominio;
using Projeto.Dominio.Familias;

namespace Projeto.TestesDeUnidade.Dominio.Builder
{
    public class FamiliaBuilder
    {
        public virtual string NomeDoResponsavel { get;  set; }
        public virtual string Telefone { get;  set; }
        public virtual string Cpf_responsavel { get;  set; }
        public virtual decimal RendaTotalDaFamilia { get;  set; }
        public virtual int QuantidadeDeDependentes { get;  set; }

        public FamiliaBuilder()
        {
            NomeDoResponsavel = "João Pessoa";
            Telefone = "67 981373178";
            Cpf_responsavel = "01756232288";
            RendaTotalDaFamilia = 1500;
            QuantidadeDeDependentes = 1;
        }

        public Familia Criar()
        {
            var familia = new Familia(NomeDoResponsavel, Telefone, Cpf_responsavel, RendaTotalDaFamilia, QuantidadeDeDependentes);
            return familia;
        }

        public FamiliaBuilder ComCpf(string cpf)
        {
            Cpf_responsavel = cpf;
            return this;
        }

        public FamiliaBuilder ComTelefone(string telefone)
        {
            Telefone = telefone;
            return this;
        }

        public FamiliaBuilder ComNome(string nome)
        {
            NomeDoResponsavel = nome;   
            return this;
        }
    }
}
