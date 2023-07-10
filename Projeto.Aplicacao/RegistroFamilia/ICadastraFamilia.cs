using Projeto.Aplicacao.DTOs.Requests;
using Projeto.Dominio;

namespace Projeto.Aplicacao.RegistroFamilia
{
    public interface ICadastraFamilia
    {
        Familia Cadastrarfamilia(FamiliaRequestDto familiaRequestDto);
    }
}
