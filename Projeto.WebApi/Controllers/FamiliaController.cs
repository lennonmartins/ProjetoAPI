using Microsoft.AspNetCore.Mvc;
using Projeto.Aplicacao.DTOs.Requests;
using Projeto.Aplicacao.Familias;

namespace Projeto.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FamiliaController : ControllerBase
    {
        private readonly ICadastraFamilia _cadastraFamilia;
        private readonly AtualizaFamilia _atualizaFamilia;
        private readonly IObtemFamilia _obterFamilia;

        public FamiliaController(ICadastraFamilia cadastraFamilia, IObtemFamilia obtemFamilia, AtualizaFamilia atualizaFamilia)
        {
            _cadastraFamilia = cadastraFamilia;
            _obterFamilia = obtemFamilia;
            _atualizaFamilia = atualizaFamilia;
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
            var familiaPontuadaRetornada = _obterFamilia.ObterComPontuacaoPeloCpfDoResponsavel(cpfDoResponsavel);
            return Ok(familiaPontuadaRetornada);
        }

        [HttpPut, Route("atualizar")]
        public IActionResult Atualizar([FromBody] FamiliaRequestDto familiaRequestDto, int id)
        {
            var familiaAtualizada = _atualizaFamilia.Atualizar(familiaRequestDto, id);
            return Ok(familiaAtualizada);
        }

    }
}
