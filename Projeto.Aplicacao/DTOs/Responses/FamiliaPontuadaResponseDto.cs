using Projeto.Dominio;

namespace Projeto.Aplicacao.DTOs.Responses
{
    public class FamiliaPontuadaResponseDto
    {
        public string NomeDoResponsavel { get; set; }
        public Pontuacao Pontos { get; set; }
        public string Telefone { get; set;}
    }
}
