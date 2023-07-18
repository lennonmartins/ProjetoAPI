using Microsoft.AspNetCore.Mvc;
using Projeto.Aplicacao.DTOs.Requests;
using Projeto.Aplicacao.Familias;
using Projeto.Aplicacao.ServicoDePontuacao;

namespace Projeto.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FamiliaController : ControllerBase
    {
        private readonly ICadastraFamilia _cadastraFamilia;
        private readonly IPontuaFamilia _pontuaFamilia;

        public FamiliaController(ICadastraFamilia cadastraFamilia, IPontuaFamilia pontuaFamilia )
        {
            _cadastraFamilia = cadastraFamilia;
            _pontuaFamilia = pontuaFamilia;
        }

        [HttpPost, Route("")]
        public IActionResult Cadastrar([FromBody] FamiliaRequestDto familiaRequestDto)
        {
            var familiaCadastrada = _cadastraFamilia.Cadastrar(familiaRequestDto);
            return Ok(familiaCadastrada);
        }
    }
}
