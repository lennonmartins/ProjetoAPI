using Projeto.Aplicacao;
using Projeto.Dominio;
using Projeto.Infra;

namespace Projeto.WebApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<CadastraFamiliaService>();
            services.AddScoped<IFamiliaRepositorio, FamiliaRepositorio>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


        }
    }
}
