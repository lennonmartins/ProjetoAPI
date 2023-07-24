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
        private readonly IObtemFamilia _obterFamilia;

        public FamiliaController(ICadastraFamilia cadastraFamilia, IObtemFamilia obterFamilia)
        {
            _cadastraFamilia = cadastraFamilia;
            _obterFamilia = obterFamilia;   
        }

        [HttpPost, Route("")]
        public IActionResult Cadastrar([FromBody] FamiliaRequestDto familiaRequestDto)
        {
            var familiaCadastrada = _cadastraFamilia.Cadastrar(familiaRequestDto);
            return Ok(familiaCadastrada);
        }

        [HttpGet("porCpf/{cpfDoResponsavel}")]
        public IActionResult BuscarPeloCpfDoResponsavel(string cpfDoResponsavel)
        {
            var familiaPontuadaRetornada = _obterFamilia.ObterPeloCpfDoResponsavel(cpfDoResponsavel);
            return Ok(familiaPontuadaRetornada);
        }
    }
}
