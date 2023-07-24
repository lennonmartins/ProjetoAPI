using AutoMapper;
using Projeto.Aplicacao.DTOs.Responses;
using Projeto.Aplicacao.ServicoDePontuacao;
using Projeto.Dominio;
using Projeto.Infra;

namespace Projeto.Aplicacao.Familias
{
    public class ObtemFamilia : IObtemFamilia
    {
        private readonly IFamiliaRepositorio _familiaRepositorio;
        private readonly IPontuaFamilia _pontuaFamilia;
        private readonly IMapper _mapper;
        private readonly PontuacaoRepositorio _pontuacaoRepositorio;
        public ObtemFamilia(IFamiliaRepositorio familiaRepositorio, IPontuaFamilia pontuaFamilia, IMapper mapper, PontuacaoRepositorio pontuacaoRepositorio) 
        {
            _familiaRepositorio = familiaRepositorio;    
            _pontuaFamilia = pontuaFamilia;
            _mapper = mapper;
            _pontuacaoRepositorio = pontuacaoRepositorio;
        }
        public FamiliaPontuadaResponseDto ObterPeloCpfDoResponsavel(string cpfDoResponsavel)
        {
            var familiaRetornada = _familiaRepositorio.ObterPeloCpfDoResponsavel(cpfDoResponsavel);
            var pontuacaoDaFamilia = _pontuacaoRepositorio.ObterPeloId(familiaRetornada.Id);
            var familiaPontuada = _pontuaFamilia.PontuarPelosCriteriosAtendidos(familiaRetornada, pontuacaoDaFamilia);
            var familiaReponsePontuada = _mapper.Map<FamiliaPontuadaResponseDto>(familiaPontuada);
            return familiaReponsePontuada;
        }
    }
}
