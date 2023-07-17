using Microsoft.AspNetCore.Mvc;
using Projeto.Aplicacao.ListagemDeFamilias;
using Projeto.Aplicacao.ServicoDePontuacao;

namespace Projeto.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PontuacaoController : ControllerBase
    {
        private readonly IPontuaFamilia _pontuaFamilia;
        private readonly IListagemDeFamilias _listagemDeFamilias;
        public PontuacaoController(IPontuaFamilia pontuaFamilia, IListagemDeFamilias listagemDeFamilia) 
        {
            _pontuaFamilia = pontuaFamilia;
            _listagemDeFamilias = listagemDeFamilia;
        }

        [HttpGet ("porCpf/{cpfDoResponsavel}")]
        public IActionResult BuscarFamiliaComPontuacao(string cpfDoResponsavel)
        {
            var familiaPontuadaRetornada = _pontuaFamilia.PontuarPelosCriteriosAtendidos(cpfDoResponsavel);
            return Ok(familiaPontuadaRetornada);
        }

        [HttpGet, Route("listagem")]
        public IActionResult BuscarListaDeFamiliasPelaPontuacao()
        {
            var familiasRetornadas = _listagemDeFamilias.ObterListaOrdenadaPorPontos();
            return Ok(familiasRetornadas);
        }
    }
}
