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
        private readonly AlteraFamilia _atualizaFamilia;
        private readonly IObtemFamilia _obtemFamilia;
        private readonly RemoveFamilia _removeFamilia;

        public FamiliaController(ICadastraFamilia cadastraFamilia, IObtemFamilia obtemFamilia, AlteraFamilia atualizaFamilia, RemoveFamilia removeFamilia )
        {
            _cadastraFamilia = cadastraFamilia;
            _obtemFamilia = obtemFamilia;
            _atualizaFamilia = atualizaFamilia;
            _removeFamilia = removeFamilia;
        }

        [HttpPost, Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] FamiliaRequestDto familiaRequestDto)
        {
            var familiaCadastrada = _cadastraFamilia.Cadastrar(familiaRequestDto);
            return Ok(familiaCadastrada);
        }

        [HttpGet("porCpf/{cpfDoResponsavel}")]
        public IActionResult BuscarPeloCpfDoResponsavel(string cpfDoResponsavel)
        {
            var familiaPontuadaRetornada = _obtemFamilia.ObterComPontuacaoPeloCpfDoResponsavel(cpfDoResponsavel);
            return Ok(familiaPontuadaRetornada);
        }

        [HttpPut, Route("atualizar")]
        public IActionResult Atualizar([FromBody] FamiliaRequestDto familiaRequestDto, int id)
        {
            var familiaAtualizada = _atualizaFamilia.Altera(familiaRequestDto, id);
            return Ok(familiaAtualizada);
        }

        [HttpDelete, Route("remover")]
        public IActionResult Remover(int id)
        {
            _removeFamilia.Remover(id);
            return Ok();
        }

    }
}
