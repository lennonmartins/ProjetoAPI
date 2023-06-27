using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
