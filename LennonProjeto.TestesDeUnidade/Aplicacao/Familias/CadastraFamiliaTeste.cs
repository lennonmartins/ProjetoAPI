using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;
using Projeto.Aplicacao.DTOs.Requests;
using Projeto.Aplicacao.Familias;
using Projeto.Dominio;

namespace Projeto.TestesDeUnidade.Aplicacao.Familias
{
    [TestFixture]
    public class CadastraFamiliaTeste
    {
        private ICadastraFamilia _cadastraFamilia;
        private IFamiliaRepositorio _familiaRepositorio;
        [SetUp]
         public void SetUp()
        {
            _cadastraFamilia = Substitute.For<ICadastraFamilia>();
            _familiaRepositorio = Substitute.For<IFamiliaRepositorio>();
        }

        [Test]
        public void Deve_cadastrar_uma_familia()
        {
            var familiaDto = new FamiliaRequestDto()
            {
                NomeDoResponsavel = "Lennon",
                Telefone = "6981373178",
                CPF = "01756233288",
                RendaTotalDaFamilia = 0,
                QuantidadeDeDependentes = 0
            };


            _cadastraFamilia.Cadastrar(familiaDto);

            _familiaRepositorio.Received(1).CadastrarNova(Arg.Is<Familia>(familia => 
                                                                            familia.NomeDoResponsavel == familiaDto.NomeDoResponsavel
                                                                            && familia.Telefone == familiaDto.Telefone
                                                                            && familia.Cpf_responsavel == familiaDto.CPF
                                                                            && familia.RendaTotalDaFamilia == familiaDto.RendaTotalDaFamilia                                                  && familia.QuantidadeDeDependentes ==               familiaDto.QuantidadeDeDependentes));
         }


    }
}
