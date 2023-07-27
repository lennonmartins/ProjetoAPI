using NSubstitute;
using NUnit.Framework;
using Projeto.Aplicacao.DTOs.Responses;
using Projeto.Aplicacao.Familias;
using Projeto.Dominio.Familias;
using Projeto.Dominio.Pontuacoes;
using Projeto.TestesDeUnidade.Dominio.Builder;

namespace Projeto.TestesDeUnidade.Aplicacao
{
    [TestFixture]
    public class ListaFamiliaTeste
    {
        private IFamiliaRepositorio _familiaRepositorio;
        private IObtemFamilia _obtemFamilia;
        private ListaFamilia _listaFamilia;
        [SetUp]
        public void SetUp()
        {   
            _familiaRepositorio = Substitute.For<IFamiliaRepositorio>();
            _obtemFamilia = Substitute.For<IObtemFamilia>();
            _listaFamilia = new ListaFamilia(_familiaRepositorio, _obtemFamilia);   
        }
        [Test]
        public void Deve_obter_uma_lista_de_familia_ordenada_por_pontos()
        {
            var familiaComRenda = new FamiliaBuilder().ComPontos(new Pontuacao(3)).ComCpf("02512345688").Criar();
            var familiaSemRenda = new FamiliaBuilder().ComPontos(new Pontuacao(5)).ComRenda(0).Criar();
            var famliasRetornadas = new List<Familia>
            {
                familiaComRenda,
                familiaSemRenda
            };

            var familiasOrdenadasEsperadas = new List<FamiliaPontuadaResponseDto>
            {  new FamiliaPontuadaResponseDto
                {
                    NomeDoResponsavel = familiaComRenda.NomeDoResponsavel,
                    Pontos = familiaComRenda.Pontos.Last().Pontos
                },
                new FamiliaPontuadaResponseDto
                {
                    NomeDoResponsavel = familiaSemRenda.NomeDoResponsavel,
                    Pontos = familiaSemRenda.Pontos.Last().Pontos
                }
            };

            _familiaRepositorio.ObterTodas().Returns(famliasRetornadas);
            _obtemFamilia.ObterComPontuacaoPeloCpfDoResponsavel(Arg.Any<string>())
                .Returns(familiasOrdenadasEsperadas[0], familiasOrdenadasEsperadas[1]);

            var familiasPontuadas = _listaFamilia.ObterListaOrdenadaPorPontos();

            Assert.True(familiasOrdenadasEsperadas[1].Equals(familiasPontuadas.First()));
        }
    }
}
