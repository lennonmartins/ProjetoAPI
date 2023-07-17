using Projeto.Aplicacao.ListagemDeFamilias;
using Projeto.Aplicacao.RegistroFamilia;
using Projeto.Aplicacao.ServicoDePontuacao;
using Projeto.Dominio;
using Projeto.Infra;
using Projeto.WebApi.AutoMapper;

namespace Projeto.WebApi
{
    public static class DependencyInjectionConfig
    {
        public static void Configuracao(IServiceCollection services){
            services.AddScoped<IFamiliaRepositorio, FamiliaRepositorio>();
            services.AddScoped<ICadastraFamilia, CadastraFamiliaService>();
            services.AddScoped<GerenciadorDeCriterios>();
            services.AddScoped<ValidacaoDeCriteriosAtendidos>();
            services.AddScoped<IPontuaFamilia, PontuaFamilia>();
            services.AddScoped<IListagemDeFamilias, ListagemDeFamilias>();
            services.AddAutoMapper(typeof(AutoMapperProfile));
        }

    }
}
