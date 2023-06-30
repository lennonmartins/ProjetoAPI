using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Bytecode.Lightweight;
using StructureMap;
using System.Security.Cryptography.X509Certificates;

namespace Projeto.Infra
{
    public class NHibernateRegistry : IDisposable
    {
        public ISession Session;
        public ITransaction Transaction;
        public static ISessionFactory SessionFactory;

        public NHibernateRegistry() {

            SessionFactory = ObterSessionFactory();
            Session = SessionFactory.OpenSession();
            Transaction = Session.BeginTransaction();

            /*For<ISessionFactory>().Singleton().Use(ObterSessionFactory());
            For<ISession>().ContainerScoped().Use(x => x.GetInstance<ISessionFactory>().OpenSession());*/
        }

        public static ISessionFactory ObterSessionFactory()
        {
            //Para conexão em memória
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFileName=|DataDirectory|\ContatoDevmedia.mdf;Integrated Security=True;Connect Timeout=30";

                return Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString)) // Precisa?
                    .Mappings(c => c.FluentMappings.AddFromAssemblyOf<FamiliaMap>())
                    .ExposeConfiguration(configuracao => configuracao.SetProperty("current_session_context_class", "thread_static"))
                    .BuildSessionFactory();

        }

        public void Dispose()
        {
            if (SessionFactory != null)
            {
                SessionFactory.Dispose();
            }
        }
    }
}
