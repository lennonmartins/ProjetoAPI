using Projeto.Aplicacao.DTOs;
using Projeto.Dominio;
using Projeto.Infra;
using Projeto.WebApi.Mapeadores;

namespace Projeto.Aplicacao
{
    public class CadastraFamiliaService
    {
        private readonly IFamiliaRepositorio _familiaRepositorio;
        public CadastraFamiliaService(IFamiliaRepositorio familiaRepositorio) { 
            _familiaRepositorio = familiaRepositorio;
        }
        public Familia Cadastrarfamilia(FamiliaRequestDto familiaRequestDto)
        {
            var familia = MapeadorDeFamilia.MapearFamiliaRequest(familiaRequestDto);
            _familiaRepositorio.Salvar(familia);
            return familia;
        }
    }
}
