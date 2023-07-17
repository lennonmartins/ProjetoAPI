using Projeto.Infra;
using Projeto.Infra.Migrations;
using Projeto.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        ConfiguraMigracao.ConfigurarMigracao();

        // Add services to the container.
        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        NHibernateRegistry.ObterSessionFactory(builder.Services);
        DependencyInjectionConfig.Configuracao(builder.Services);

        var app = builder.Build();

        // Configura��o the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}

