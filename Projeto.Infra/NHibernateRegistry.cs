using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Projeto.Infra
{
    public static class NHibernateRegistry 
    {
        public static void  ObterSessionFactory(IServiceCollection services) { 
            IConfiguration configuracao = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            var connStr = configuracao.GetConnectionString("DefaultConnection");

            var sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connStr))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<FamiliaMap>())
                .ExposeConfiguration(cfg => cfg.SetProperty("current_session_context_class", "web"))
                .BuildSessionFactory();

            services.AddScoped(factory => sessionFactory.OpenSession());
            services.AddSingleton(sessionFactory);

        }
    }
}
