using Autofac;
using FluentNHibernate.Cfg;
using Projeto.Aplicacao;
using Projeto.Aplicacao.Controllers;
using Projeto.Dominio;
using Projeto.Infra;
using Projeto.WebApi.AutoMapper;
using System;

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

        services.AddScoped(factory => sessionFactory.OpenSession());
        services.AddSingleton(sessionFactory);

       
        services.AddScoped<IFamiliaRepositorio, FamiliaRepositorio>();
        services.AddScoped<ICadastraFamilia, CadastraFamiliaService>();
        services.AddAutoMapper(typeof(AutoMapperProfile));
    }
}


/*
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var construtor = new ContainerBuilder();

*//*var NHibernateRegistry = new NHibernateRegistry();

construtor.Register(c => NHibernateRegistry.ObterSessionFactory()).As<ISessionFactory>().SingleInstance();

construtor.Register(x => x.Resolve<ISessionFactory>().OpenSession())
    .As<NHibernate.ISession>()
    .InstancePerLifetimeScope();

construtor.Register(c => new NHibernateRegistry()).As<Registry>();
 construtor.Build();
*/
/*builder.Services.AddScoped<NHibernate.ISession, NHibernate.Session>();*//*


builder.Services.AddScoped<IFamiliaRepositorio, FamiliaRepositorio>();
builder.Services.AddScoped<ICadastraFamilia, CadastraFamiliaService>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();*/


