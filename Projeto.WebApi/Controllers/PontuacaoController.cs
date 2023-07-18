using Microsoft.AspNetCore.Mvc;
using Projeto.Aplicacao.Familias;
using Projeto.Aplicacao.ServicoDePontuacao;

namespace Projeto.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PontuacaoController : ControllerBase
    {
        private readonly IPontuaFamilia _pontuaFamilia;
        private readonly IListaFamilia _listagemDeFamilias;
        private readonly IObterFamilia _obterFamilia;
        public PontuacaoController(IPontuaFamilia pontuaFamilia, IListaFamilia listagemDeFamilia, IObterFamilia obterFamilia) 
        {
            _pontuaFamilia = pontuaFamilia;
            _listagemDeFamilias = listagemDeFamilia;
            _obterFamilia = obterFamilia;
        }

        [HttpGet ("porCpf/{cpfDoResponsavel}")]
        public IActionResult BuscarFamiliaPeloCpfDoResponsavel(string cpfDoResponsavel)
        {
            var familiaPontuadaRetornada = _obterFamilia.ObterResponsavelPeloCpf(cpfDoResponsavel);
            return Ok(familiaPontuadaRetornada);
        }

        [HttpGet, Route("listagem")]
        public IActionResult BuscarFamiliasOrdenadasPelaPontuacao()
        {
            var familiasRetornadas = _listagemDeFamilias.ObterListaOrdenadaPorPontos();
            return Ok(familiasRetornadas);
        }
    }
}
