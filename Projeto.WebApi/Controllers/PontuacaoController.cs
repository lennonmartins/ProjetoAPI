using Microsoft.AspNetCore.Mvc;
using Projeto.Aplicacao.Familias;
using Projeto.Aplicacao.Pontuacoes;

namespace Projeto.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PontuacaoController : ControllerBase
    {
        private readonly IPontuaFamilia _pontuaFamilia;
        private readonly IListaFamilia _listaFamilia;
        public PontuacaoController(IPontuaFamilia pontuaFamilia, IListaFamilia listaFamilia) 
        {
            _pontuaFamilia = pontuaFamilia;
            _listaFamilia = listaFamilia;
        }

        [HttpGet]
        public IActionResult BuscarFamiliaComPontuacao(string cpfDoResponsavel)
        {
            var familiaPontuadaRetornada = _pontuaFamilia.PontuarPelosCriteriosAtendidos(cpfDoResponsavel);
            return Ok(familiaPontuadaRetornada);
        }

        [HttpGet, Route("listagem")]
        public IActionResult BuscarListaDeFamiliasPelaPontuacao()
        {
            var familiasRetornadas = _listaFamilia.ObterListaOrdenadaPorPontos();
            return Ok(familiasRetornadas);
        }
    }
}
