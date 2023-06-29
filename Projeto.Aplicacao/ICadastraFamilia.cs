using Projeto.Aplicacao.DTOs;
using Projeto.Dominio;

namespace Projeto.Aplicacao.Controllers
{
    public interface ICadastraFamilia
    {
        Familia Cadastrarfamilia(FamiliaRequestDto familiaRequestDto);
    }
}
