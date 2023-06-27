namespace Projeto.Dominio
{
    public class Familia
    {
        public string NomeDoResponsavel { get; private set; }
        public string Telefone { get; private set; }    
        public string CPF { get; private set; }
        public decimal RendaTotalDaFamilia { get; private set; }
        public int QuantidadeDeDependentes { get; private set; }

        public Familia(string nomeDoResponsavel, string telefone, string cpf, decimal rendaTotalDaFamilia, int quantidadeDeDependentes)
        {
            ValidarNomeVazioOuNulo(nomeDoResponsavel);
            ValidarSeContatoEhNuloOuVaizo(telefone);
            ValidarSeCpfVazioOuNulo(cpf);
            NomeDoResponsavel = nomeDoResponsavel;
            Telefone = telefone;
            CPF = cpf;  
            RendaTotalDaFamilia = rendaTotalDaFamilia;
            QuantidadeDeDependentes = quantidadeDeDependentes;
        }

        private void ValidarNomeVazioOuNulo(string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                throw new ArgumentException("Responsável não pode ter nome vazio ou nulo.");
            }
        }

        private void ValidarSeContatoEhNuloOuVaizo(string telefone)
        {
            if (string.IsNullOrEmpty(telefone))
            {
                throw new ArgumentException("Responsavel deve ter um telefone para contato.");
            }
        }

        private void ValidarSeCpfVazioOuNulo(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
            {
                throw new ArgumentException("Responsável deve conter um CPF para registro.");
            }
        }
    }
}
