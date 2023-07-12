using FluentMigrator.Runner;
using Projeto.Dominio;
using Projeto.Infra;
using Projeto.WebApi.AutoMapper;
using System.Reflection;
using Projeto.Aplicacao.Familias;
using Projeto.Aplicacao.Pontuacoes;
using Projeto.Dominio.Familias;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        ConfigurarMigracao(builder.Services);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        NHibernateRegistry.ObterSessionFactory(builder.Services);

        builder.Services.AddScoped<IFamiliaRepositorio, FamiliaRepositorio>();
        builder.Services.AddScoped<ICadastraFamilia, CadastraFamilia>();
        builder.Services.AddScoped<FabricaDeCriterios>();
        builder.Services.AddScoped<ValidacaoDeCriteriosAtendidos>();
        builder.Services.AddScoped<IPontuaFamilia, PontuaFamilia>();
        builder.Services.AddScoped<IListaFamilia, ListaFamilia>();
        builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

        var app = builder.Build();

        // Configuração the HTTP request pipeline.
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

    private static void ConfigurarMigracao(IServiceCollection services)
    {
        var connStr = @"Server=localhost;Database=ProjetoLennon;User Id=sa;Password=PapelZero.123;";

        var serviceProvider = new ServiceCollection()
            .AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
                .AddSqlServer2012()
                .WithGlobalConnectionString(connStr)
                .ScanIn(Assembly.LoadFrom(@"bin\Debug\net6.0\Projeto.Infra.dll")).For.Migrations())
            .AddLogging(lb => lb.AddFluentMigratorConsole())
            .BuildServiceProvider();

        var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
        runner.MigrateUp();

    }
}

