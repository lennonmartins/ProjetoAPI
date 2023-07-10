using AutoMapper;
using Projeto.Aplicacao.DTOs;
using Projeto.Dominio;

namespace Projeto.Aplicacao.Servicos
{
    public class PontuaFamilia : IPontuaFamilia
    {
        private readonly IFamiliaRepositorio _familiaRepositorio;
        private readonly Criterios validacoes;
        private readonly IMapper _mapper;
        private readonly List<IValidaCriteriosAtendidos> criterios = new()
        {
            new CriterioQuantidadeDeDependentes(),
            new CriterioRenda(),
        };
        public PontuaFamilia(IFamiliaRepositorio familiaRepositorio, Criterios criterios, IMapper mapper)
        {
            _familiaRepositorio = familiaRepositorio;
            validacoes = criterios;
            _mapper = mapper;
        }

        public FamiliaPontuadaResponseDto PontuarFamiliaPelosCriteriosAtendidos(string cpfDoReponsavel)
        {
            Familia familiaRetornada = BuscarFamiliaPeloCpfDoResponsavel(cpfDoReponsavel);
            validacoes.SetarCriterios(criterios);
            validacoes.Resultado(familiaRetornada);
            var familia= _mapper.Map<FamiliaPontuadaResponseDto>(familiaRetornada);
            return familia;
        }

        private Familia BuscarFamiliaPeloCpfDoResponsavel(string cpfDoReponsavel)
        {
            return _familiaRepositorio.BuscarFamiliaPeloCpfDoResponsavel(cpfDoReponsavel);
        }
    }
}
