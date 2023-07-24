using AutoMapper;
using FluentNHibernate.Automapping;
using NSubstitute;
using NUnit.Framework;
using Projeto.Aplicacao.DTOs.Requests;
using Projeto.Aplicacao.DTOs.Responses;
using Projeto.Aplicacao.Familias;
using Projeto.Aplicacao.ServicoDePontuacao;
using Projeto.Dominio;
using Projeto.TestesDeUnidade.Dominio.Builder;

namespace Projeto.TestesDeUnidade.Aplicacao.Familias
{
    [TestFixture]
    public class ObtemFamiliaTeste
    {
        private IObtemFamilia _obtemFamilia;
        private IFamiliaRepositorio _familiaRepositorio;
        private IPontuaFamilia _pontuaFamilia;
        private IMapper _mapper;
        
        [SetUp]
        public void SetUp()
        {
            _obtemFamilia = Substitute.For<IObtemFamilia>();
            _familiaRepositorio = Substitute.For<IFamiliaRepositorio>();
            _pontuaFamilia = Substitute.For<IPontuaFamilia>();
            _mapper = Substitute.For<IMapper>();
        }

        /*[Test]
        public void Deve_obter_uma_familia_pelo_cpf_do_responsavel()
        {
            var cpf = "01756232288";
            var pontuacao = 3;
            var familia = new FamiliaBuilder().ComCpf(cpf).Criar();

            var familiaResponse = new FamiliaPontuadaResponseDto
            {
                NomeDoResponsavel = familia.NomeDoResponsavel,
                Pontos = pontuacao,
                Telefone = familia.Telefone
            };
            _familiaRepositorio.ObterPeloCpfDoResponsavel(cpf).Returns(familia);

            familia.AdicionarPontos(pontuacao);
            var familiaPontuada = familia;
            _pontuaFamilia.PontuarPelosCriteriosAtendidos(familia).Returns(familiaPontuada);
            _mapper.Map<FamiliaPontuadaResponseDto>(familiaPontuada).Returns(familiaResponse);

            var familiaRetornada  = _obtemFamilia.ObterPeloCpfDoResponsavel(cpf);

            Assert.AreEqual(familiaPontuada, familiaRetornada);
        }*/
    }
}
