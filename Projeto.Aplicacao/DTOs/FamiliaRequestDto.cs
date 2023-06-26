namespace Projeto.WebApi.DTOs
{
    public class FamiliaRequestDto
    {
        public string NomeDoResponsavel {  get; set; } 
        public string Telefone { get; set; }   
        public string CPF { get; set; }
        public decimal RendaTotalDaFamilia { get; set; }
        public int QuantidadeDeDependentes { get; set; }
    }
}
