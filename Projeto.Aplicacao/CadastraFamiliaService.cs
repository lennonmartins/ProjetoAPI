using Projeto.Aplicacao.DTOs;
using Projeto.Dominio;
using Projeto.WebApi.Mapeadores;

namespace Projeto.Aplicacao
{
    public class CadastraFamiliaService
    {        
        public Familia Cadastrarfamilia(FamiliaRequestDto familiaRequestDto)
        {
            var familia = MapeadorDeFamilia.MapearFamiliaRequest(familiaRequestDto);
            return familia;
        }
    }
}
