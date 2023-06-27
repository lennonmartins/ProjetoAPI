using Projeto.Aplicacao.DTOs;
using Projeto.Dominio;

namespace Projeto.Aplicacao
{
    public class CadastraFamiliaService
    {        
        public Familia Cadastrarfamilia(FamiliaRequestDto familiaRequestDto)
        {
            return new Familia(
                familiaRequestDto.NomeDoResponsavel,
                familiaRequestDto.Telefone, 
                familiaRequestDto.CPF, 
                familiaRequestDto.RendaTotalDaFamilia, 
                familiaRequestDto.QuantidadeDeDependentes
                );
        }
    }
}
