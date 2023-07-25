using Microsoft.AspNetCore.Mvc;
using Projeto.Aplicacao.Familias;

namespace Projeto.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PontuacaoController : ControllerBase
    {
        
        private readonly IListaFamilia _listagemDeFamilias;
       
        public PontuacaoController( IListaFamilia listagemDeFamilia) 
        {            
            _listagemDeFamilias = listagemDeFamilia;
        }

        [HttpGet, Route("listagem")]
        public IActionResult BuscarFamiliasOrdenadasPelaPontuacao()
        {
            var familiasRetornadas = _listagemDeFamilias.ObterListaOrdenadaPorPontos();
            return Ok(familiasRetornadas);
        }
    }
}
