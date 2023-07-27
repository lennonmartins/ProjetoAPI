using Projeto.Dominio.Pontuacoes;

namespace Projeto.Dominio.Familias
{
    public class Familia
    {
        private int _id;
        public virtual int Id { get { return _id; } }
        public virtual string NomeDoResponsavel { get; protected set; }
        public virtual string Telefone { get; protected set; }
        public virtual string Cpf_responsavel { get; protected set; }
        public virtual decimal RendaTotalDaFamilia { get; protected set; }
        public virtual int QuantidadeDeDependentes { get; protected set; }
        private readonly IList<Pontuacao> _pontos = new List<Pontuacao>();
        public virtual IEnumerable<Pontuacao> Pontos  => _pontos;

        public Familia(string nomeDoResponsavel, string telefone, string cpf, decimal rendaTotalDaFamilia, int quantidadeDeDependentes)
        {
            ValidarNomeVazioOuNulo(nomeDoResponsavel);
            ValidarSeContatoEhNuloOuVaizo(telefone);
            ValidarSeCpfVazioOuNulo(cpf);
            NomeDoResponsavel = nomeDoResponsavel;
            Telefone = telefone;
            Cpf_responsavel = cpf;
            RendaTotalDaFamilia = rendaTotalDaFamilia;
            QuantidadeDeDependentes = quantidadeDeDependentes;
        }

        protected Familia() { }

        private void ValidarNomeVazioOuNulo(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentException("Responsável não pode ter nome vazio ou nulo.");
            }
        }

        private void ValidarSeContatoEhNuloOuVaizo(string telefone)
        {
            if (string.IsNullOrWhiteSpace(telefone))
            {
                throw new ArgumentException("Responsavel deve ter um telefone para contato.");
            }
        }

        private void ValidarSeCpfVazioOuNulo(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
            {
                throw new ArgumentException("Responsável deve conter um CPF para registro.");
            }
        }

        public virtual void AdiconarPontucao(Pontuacao pontuacao)
        {
          _pontos.Add(pontuacao);
        }
        
    }
}
