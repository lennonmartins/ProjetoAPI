using Projeto.Aplicacao.DTOs.Responses;
using Projeto.Aplicacao.ServicoDePontuacao;
using Projeto.Dominio.Familias;

namespace Projeto.Aplicacao.Familias
{
    public class ObtemFamilia : IObtemFamilia
    {
        private readonly IFamiliaRepositorio _familiaRepositorio;
        private readonly IPontuaFamilia _pontuaFamilia;
        public ObtemFamilia(IFamiliaRepositorio familiaRepositorio, IPontuaFamilia pontuaFamilia) 
        {
            _familiaRepositorio = familiaRepositorio;    
            _pontuaFamilia = pontuaFamilia;
        }
        public FamiliaPontuadaResponseDto ObterComPontuacaoPeloCpfDoResponsavel(string cpfDoResponsavel)
        {
            var familiaRetornada = _familiaRepositorio.ObterPeloCpfDoResponsavel(cpfDoResponsavel);
            var familiaPontuada = _pontuaFamilia.PontuarPelosCriteriosAtendidos(familiaRetornada);
            var familiaResponsePontuada = new FamiliaPontuadaResponseDto
            {
                NomeDoResponsavel = familiaPontuada.NomeDoResponsavel,
                Pontos = familiaPontuada.Pontos.Last().Pontos,
            };

            return familiaResponsePontuada;
        }
    }
}
