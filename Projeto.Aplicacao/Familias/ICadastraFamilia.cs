using Projeto.Aplicacao.DTOs.Requests;
using Projeto.Dominio;

namespace Projeto.Aplicacao.Familias
{
    public interface ICadastraFamilia
    {
        Familia Cadastrar(FamiliaRequestDto familiaRequestDto);
    }
}
