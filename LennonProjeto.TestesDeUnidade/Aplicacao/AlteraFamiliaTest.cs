using AutoMapper;
using NSubstitute;
using NUnit.Framework;
using Projeto.Aplicacao.DTOs.Requests;
using Projeto.Aplicacao.Familias;
using Projeto.Dominio.Familias;
using Projeto.TestesDeUnidade.Dominio.Builder;

namespace Projeto.TestesDeUnidade.Aplicacao
{
    [TestFixture]
    public class AlteraFamiliaTest
    {
        private AlteraFamilia _alteraFamilia;
        private IFamiliaRepositorio _familiaRepositorio;
        private IMapper _mapper;
        

        [SetUp]
        public void SetUp()
        {
            _familiaRepositorio = Substitute.For<IFamiliaRepositorio>();
            _mapper = Substitute.For<IMapper>();
            _alteraFamilia = new AlteraFamilia(_familiaRepositorio, _mapper);
        }
        [Test]
        public void Deve_alterar_uma_familia()
        {
            var nomeParaAlterar = "Lennon Martins";
            var rendaParaAlterar = 900;
            var dependentesParaAlterar = 2;

            var familiaParaAlterarDto = new FamiliaRequestDto
            {
                NomeDoResponsavel = nomeParaAlterar,
                RendaTotalDaFamilia = rendaParaAlterar,
                QuantidadeDeDependentes = dependentesParaAlterar
            };

           var familiaParaAlterar = new FamiliaBuilder()
                .ComResponsavel(nomeParaAlterar)
                .ComRenda(rendaParaAlterar)
                .ComDependentes(dependentesParaAlterar)
                .Criar();

           var familiaCadastrada = new FamiliaBuilder().Criar();
           _familiaRepositorio.ObterPor(1).Returns(familiaCadastrada);
           _mapper.Map<Familia>(Arg.Is(familiaParaAlterarDto)).Returns(familiaParaAlterar);

            var familiaAlterada = _alteraFamilia.Altera(familiaParaAlterarDto, 1);

            Assert.AreEqual(familiaAlterada.NomeDoResponsavel, familiaParaAlterarDto.NomeDoResponsavel);
        }
    }
}
