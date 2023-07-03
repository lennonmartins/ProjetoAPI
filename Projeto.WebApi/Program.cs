using Autofac;
using FluentMigrator.Runner;
using FluentNHibernate.Cfg;
using Projeto.Aplicacao;
using Projeto.Aplicacao.Controllers;
using Projeto.Dominio;
using Projeto.Infra;
using Projeto.WebApi.AutoMapper;
using System.Reflection;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        ConfigureNHibernate(builder.Services);

        // Add services to the container.
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var construtor = new ContainerBuilder();

        builder.Services.AddScoped<IFamiliaRepositorio, FamiliaRepositorio>();
        builder.Services.AddScoped<ICadastraFamilia, CadastraFamiliaService>();

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

    private static void ConfigureNHibernate(IServiceCollection services)
    {
        // Configuração do NHibernate
        var connStr = @"Server=localhost;Database=ProjetoLennon;User Id=sa;Password=PapelZero.123;";

        var sessionFactory = Fluently.Configure()
            .Database(FluentNHibernate.Cfg.Db.MsSqlConfiguration.MsSql2012.ConnectionString(connStr))
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<FamiliaMap>())
            .ExposeConfiguration(cfg => cfg.SetProperty("current_session_context_class", "web"))
            .BuildSessionFactory();

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
        
        services.AddScoped(factory => sessionFactory.OpenSession());
        services.AddSingleton(sessionFactory);
        services.AddScoped<IFamiliaRepositorio, FamiliaRepositorio>();
        services.AddScoped<ICadastraFamilia, CadastraFamiliaService>();
        services.AddAutoMapper(typeof(AutoMapperProfile));

    }
}

