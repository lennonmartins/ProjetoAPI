using Microsoft.AspNetCore.Mvc;
using Projeto.Aplicacao;
using Projeto.Dominio;

namespace Projeto.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FamiliaController : ControllerBase
    {
        readonly CadastraFamiliaService cadastraFamiliaService = new();


        [HttpPost]
        public IActionResult CadastrarFamilia()
        {
            var nomeDoResponsavel = "Lennon";
            var telefone = "67 981373178";
            var cpf = "01756232288";
            var rendaTotalDaFamilia = 1500;
            var quantidadeDeDependentes = 0;

            var familiaCadastrada = cadastraFamiliaService.Cadastrarfamilia(nomeDoResponsavel,telefone,cpf,rendaTotalDaFamilia,quantidadeDeDependentes);
            return Ok(familiaCadastrada);
        }
    }
}
