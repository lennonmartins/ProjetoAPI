using Microsoft.AspNetCore.Mvc;
using Projeto.Aplicacao.DTOs;
using Projeto.Aplicacao.RegistroFamilia;

namespace Projeto.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FamiliaController : ControllerBase
    {
        readonly ICadastraFamilia _cadastraFamilia;

        public FamiliaController(ICadastraFamilia cadastraFamilia)
        {
            _cadastraFamilia = cadastraFamilia;
        }

        [HttpPost]
        public IActionResult CadastrarFamilia([FromBody] FamiliaRequestDto familiaRequestDto)
        {
            var familiaCadastrada = _cadastraFamilia.Cadastrarfamilia(familiaRequestDto);
            return Ok(familiaCadastrada);
        }
    }
}
