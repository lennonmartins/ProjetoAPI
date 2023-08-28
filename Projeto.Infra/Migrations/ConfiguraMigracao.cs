using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Projeto.Infra.Migrations
{
    public static class ConfiguraMigracao
    {
        public static void ConfigurarMigracao()
        {

            IConfiguration configuracao = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connStr = configuracao.GetConnectionString("DefaultConnection");

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
}
