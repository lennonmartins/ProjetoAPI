namespace Projeto.Aplicacao.DTOs.Requests
{
    public class FamiliaRequestDto
    {
        public string NomeDoResponsavel { get; set; }
        public string Telefone { get; set; }
        public string Cpf_responsavel { get; set; }
        public decimal RendaTotalDaFamilia { get; set; }
        public int QuantidadeDeDependentes { get; set; }
    }
}
