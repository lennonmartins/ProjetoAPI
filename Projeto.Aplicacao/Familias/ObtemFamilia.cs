using AutoMapper;
using Projeto.Aplicacao.DTOs.Responses;
using Projeto.Aplicacao.ServicoDePontuacao;
using Projeto.Dominio.Familias;

namespace Projeto.Aplicacao.Familias
{
    public class ObtemFamilia : IObtemFamilia
    {
        private readonly IFamiliaRepositorio _familiaRepositorio;
        private readonly IPontuaFamilia _pontuaFamilia;
        private readonly IMapper _mapper;
        public ObtemFamilia(IFamiliaRepositorio familiaRepositorio, IPontuaFamilia pontuaFamilia, IMapper mapper) 
        {
            _familiaRepositorio = familiaRepositorio;    
            _pontuaFamilia = pontuaFamilia;
            _mapper = mapper;
        }
        public FamiliaPontuadaResponseDto ObterResponsavelPeloCpf(string cpfDoResponsavel)
        {
            var familiaRetornada = _familiaRepositorio.ObterPeloCpfDoResponsavel(cpfDoResponsavel);
            var familiaPontuada = _pontuaFamilia.PontuarPelosCriteriosAtendidos(familiaRetornada);
            var familiaResponsePontuada = new FamiliaPontuadaResponseDto
            {
                NomeDoResponsavel = familiaPontuada.NomeDoResponsavel,
                Pontos = familiaPontuada.Pontos.Last().Pontos,
            };
               /* _mapper.Map<FamiliaPontuadaResponseDto>(familiaPontuada);*/
            return familiaResponsePontuada;
        }
    }
}
