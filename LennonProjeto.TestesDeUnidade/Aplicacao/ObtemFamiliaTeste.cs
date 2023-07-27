using NSubstitute;
using NUnit.Framework;
using Projeto.Aplicacao.Familias;
using Projeto.Aplicacao.ServicoDePontuacao;
using Projeto.Dominio.Familias;
using Projeto.Dominio.Pontuacoes;
using Projeto.TestesDeUnidade.Dominio.Builder;

namespace Projeto.TestesDeUnidade.Aplicacao
{
    [TestFixture]
    public class ObtemFamiliaTeste
    {
        private IFamiliaRepositorio _familiaRepositorio;
        private IPontuaFamilia _pontuaFamilia;
        private IObtemFamilia _obtemFamilia;

        [SetUp]
        public void SetUp()
        {
            _familiaRepositorio = Substitute.For<IFamiliaRepositorio>();
            _pontuaFamilia = Substitute.For<IPontuaFamilia>();
            _obtemFamilia = new ObtemFamilia(_familiaRepositorio, _pontuaFamilia);
        }

        [Test]
        public void Deve_obter_uma_familia()
        {
            int pontos = 5;
            var familia = new FamiliaBuilder().ComPontos(new Pontuacao(pontos)).Criar();

            _familiaRepositorio.ObterPeloCpfDoResponsavel(Arg.Any<string>()).Returns(familia);
            _pontuaFamilia.PontuarPelosCriteriosAtendidos(Arg.Any<Familia>()).Returns(familia);
            
            var familiaDto = _obtemFamilia.ObterComPontuacaoPeloCpfDoResponsavel(Arg.Any<string>());

            Assert.AreEqual(familiaDto.NomeDoResponsavel, familia.NomeDoResponsavel);
        }
    }
}
