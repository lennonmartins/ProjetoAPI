using Microsoft.AspNetCore.Mvc;
using Projeto.Aplicacao.ServicoDePontuacao;

namespace Projeto.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PontuacaoController : ControllerBase
    {
        private readonly IPontuaFamilia _pontuaFamilia;
        public PontuacaoController(IPontuaFamilia pontuaFamilia) 
        {
            _pontuaFamilia = pontuaFamilia;
        }

        [HttpGet]
        public IActionResult BuscarFamiliaComPontuacao(string cpfDoResponsavel)
        {
            var familiaPontuadaRetornada = _pontuaFamilia.PontuarFamiliaPelosCriteriosAtendidos(cpfDoResponsavel);
            return Ok(familiaPontuadaRetornada);
        }
    }
}
