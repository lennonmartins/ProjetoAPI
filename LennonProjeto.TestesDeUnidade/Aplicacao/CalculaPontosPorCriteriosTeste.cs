using NSubstitute;
using NUnit.Framework;
using Projeto.Aplicacao.ServicoDePontuacao;
using Projeto.TestesDeUnidade.Dominio.Builder;

namespace Projeto.TestesDeUnidade.Aplicacao
{
    [TestFixture]
    public class CalculaPontosPorCriteriosTeste
    {
        private GerenciadorDeCriterios _gerenciadorDeCriterios;
        private CalculaPontosPorCriterios _calculaPontos;

        [SetUp]
        public void SetUp()
        {
            _gerenciadorDeCriterios = Substitute.For<GerenciadorDeCriterios>();
            _calculaPontos = new CalculaPontosPorCriterios(_gerenciadorDeCriterios);   
        }

        [Test]
        public void Deve_calcular_a_quantidade_de_pontos_obtidos_por_uma_familia()
        {
            var renda = 900;
            var dependentes = 1;
            var pontosEsperados = 7;
            var familia = new FamiliaBuilder().ComRenda(renda).ComDependentes(dependentes).Criar();

            var pontosRetornados =  _calculaPontos.CalcularQuantidadeDePontos(familia);

            Assert.NotZero(pontosRetornados);
            Assert.AreEqual(pontosRetornados, pontosEsperados);
        }
    }
}
