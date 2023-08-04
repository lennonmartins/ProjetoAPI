using Projeto.Aplicacao.Familias;
using Projeto.Aplicacao.ServicoDePontuacao;
using Projeto.Dominio.Familias;
using Projeto.Infra;
using Projeto.WebApi.AutoMapper;

namespace Projeto.WebApi
{
    public static class DependencyInjectionConfig
    {
        public static void Configuracao(IServiceCollection services){
            services.AddScoped<IFamiliaRepositorio, FamiliaRepositorio>();
            services.AddScoped<ICadastraFamilia, CadastraFamilia>();
            services.AddScoped<GerenciadorDeCriterios>();
            services.AddScoped<ValidacaoDeCriteriosAtendidos>();
            services.AddScoped<IObtemFamilia, ObtemFamilia>();
            services.AddScoped<IPontuaFamilia, PontuaFamilia>();
            services.AddScoped<IListaFamilia, ListaFamilia>();
            services.AddAutoMapper(typeof(AutoMapperProfile));
        }

    }
}
