using Projeto.Aplicacao.DTOs;
using Projeto.Dominio;

namespace Projeto.Aplicacao.RegistroFamilia
{
    public interface ICadastraFamilia
    {
        Familia Cadastrarfamilia(FamiliaRequestDto familiaRequestDto);
    }
}
