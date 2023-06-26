using Projeto.Dominio;
using Projeto.WebApi.DTOs;

namespace Projeto.WebApi.Mapeadores
{
    public class MapeadorDeFamilia
    {
        public static Familia MapeadorDeFamiliaRequest(FamiliaRequestDto familiaRequestDto)
        {
            return new Familia(familiaRequestDto.NomeDoResponsavel, familiaRequestDto.Telefone, familiaRequestDto.CPF, familiaRequestDto.RendaTotalDaFamilia, familiaRequestDto.QuantidadeDeDependentes);
        }
    }
}
