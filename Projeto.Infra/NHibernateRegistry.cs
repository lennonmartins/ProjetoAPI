using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using StructureMap;

namespace Projeto.Infra
{
    public class NHibernateRegistry : Registry
    {
        public NHibernateRegistry() {

            For<ISessionFactory>().Singleton().Use(ObterSessionFactory());
            For<ISession>().ContainerScoped().Use(x => x.GetInstance<ISessionFactory>().OpenSession());
        }

        private static ISessionFactory ObterSessionFactory()
        {
            //Para conexão em memória
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFileName=|DataDirectory|\ContatoDevmedia.mdf;Integrated Security=True;Connect Timeout=30";

            try
            {
                return Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString)) // Precisa?
                    .Mappings(c => c.FluentMappings.AddFromAssemblyOf<FamiliaMap>())
                    .ExposeConfiguration(configuracao => configuracao.SetProperty("current_session_context_class", "thread_static"))
                    .BuildSessionFactory();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
