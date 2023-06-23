using System.Globalization;

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
            NomeDoResponsavel = nomeDoResponsavel;
            Telefone = telefone;
            CPF = cpf;  
            RendaTotalDaFamilia = rendaTotalDaFamilia;
            QuantidadeDeDependentes = quantidadeDeDependentes;
        }
    }
}
