using Projeto.Dominio.Familias;
using Projeto.Dominio.Pontuacoes;

namespace Projeto.TestesDeUnidade.Dominio.Builder
{
    public class FamiliaBuilder
    {
        public virtual string NomeDoResponsavel { get;  set; }
        public virtual string Telefone { get;  set; }
        public virtual string Cpf_responsavel { get;  set; }
        public virtual decimal RendaTotalDaFamilia { get;  set; }
        public virtual int QuantidadeDeDependentes { get;  set; }
        public virtual List<Pontuacao> _pontos { get; protected set; }

        public FamiliaBuilder()
        {
            NomeDoResponsavel = "João Pessoa";
            Telefone = "67 981373178";
            Cpf_responsavel = "01756232288";
            RendaTotalDaFamilia = 1500;
            QuantidadeDeDependentes = 1;
            _pontos = new List<Pontuacao>();
        }

        public Familia Criar()
        {
            var familia = new Familia(NomeDoResponsavel, Telefone, Cpf_responsavel, RendaTotalDaFamilia, QuantidadeDeDependentes);
            if (_pontos.Any())
            {
                familia.AdiconarPontucao(_pontos.Last());
            }
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

        public FamiliaBuilder ComPontos(int pontos)
        {
            var pontuacao = new Pontuacao();
            pontuacao.AdicionarPontos(pontos);
            _pontos.Add(pontuacao);
            return this;
        }

        public FamiliaBuilder ComRenda(decimal renda)
        {
            RendaTotalDaFamilia = renda;
            return this;
        }

        public FamiliaBuilder ComDependentes(int dependentes)
        {
            QuantidadeDeDependentes = dependentes;  
            return this;
        }
    }
}
