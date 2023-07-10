using Microsoft.AspNetCore.Mvc;
using Projeto.Aplicacao.DTOs;
using Projeto.Aplicacao.RegistroFamilia;
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
        public IActionResult CadastrarFamilia([FromBody] FamiliaRequestDto familiaRequestDto)
        {
            var familiaCadastrada = _cadastraFamilia.Cadastrarfamilia(familiaRequestDto);
            return Ok(familiaCadastrada);
        }

      /*  [HttpGet]
        public IActionResult BuscarFamiliaComPontuacao(string cpfDoResponsavel)
        {
            var familiaPontuadaRetornada = _pontuaFamilia.PontuarFamiliaPelosCriteriosAtendidos(cpfDoResponsavel);
            return Ok(familiaPontuadaRetornada);
        }*/
    }
}
