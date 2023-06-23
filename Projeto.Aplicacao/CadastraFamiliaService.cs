using Projeto.Dominio;

namespace Projeto.Aplicacao
{
    public class CadastraFamiliaService
    {        
        public Familia Cadastrarfamilia(string nomeDoResponsavel, string telefone, string cpf, decimal rendaTotalDaFamilia, int quantidadeDeDepedentes)
        {
            Familia famiia = new(nomeDoResponsavel, telefone, cpf, rendaTotalDaFamilia, quantidadeDeDepedentes);
            return famiia;
        }
    }
}
