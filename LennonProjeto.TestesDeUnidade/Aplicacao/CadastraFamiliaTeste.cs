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
    public class CadastraFamiliaTeste
    {
        private ICadastraFamilia _cadastraFamilia;
        private IFamiliaRepositorio _familiaRepositorio;
        private IMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            _familiaRepositorio = Substitute.For<IFamiliaRepositorio>();
            _mapper = Substitute.For<IMapper>();
            _cadastraFamilia = new CadastraFamilia(_familiaRepositorio, _mapper);
        }

        [Test]
        public void Deve_cadastrar_uma_familia()
        {
            var familiaDto = new FamiliaRequestDto
            {
                NomeDoResponsavel = "Joao Pessoa",
                Telefone = "67981373178",
                Cpf_responsavel = "85735364030",
                QuantidadeDeDependentes = 1,
                RendaTotalDaFamilia = 1500
            };
            var familia = new FamiliaBuilder().ComNome(familiaDto.NomeDoResponsavel).Criar();

            _mapper.Map<Familia>(Arg.Any<FamiliaRequestDto>()).Returns(familia);
            _familiaRepositorio.CadastrarNova(Arg.Any<Familia>());
            _cadastraFamilia.Cadastrar(familiaDto);

            _familiaRepositorio.Received(1).CadastrarNova(Arg.Is<Familia>(familia =>
                                familia.NomeDoResponsavel == familiaDto.NomeDoResponsavel));
        }
    }
}
