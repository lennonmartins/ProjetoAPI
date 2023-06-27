using Microsoft.AspNetCore.Mvc;
using Projeto.Aplicacao;
using Projeto.Dominio;
using Projeto.Aplicacao.DTOs;

namespace Projeto.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FamiliaController : ControllerBase
    {
        readonly CadastraFamiliaService cadastraFamiliaService = new();

        [HttpPost]
        public IActionResult CadastrarFamilia([FromBody] FamiliaRequestDto familiaRequestDto)
        {
            var familiaCadastrada = cadastraFamiliaService.Cadastrarfamilia(familiaRequestDto);
            return Ok(familiaCadastrada);
        }
    }
}
