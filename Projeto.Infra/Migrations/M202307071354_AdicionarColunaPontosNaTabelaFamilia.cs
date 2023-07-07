using FluentMigrator;

namespace Projeto.Infra.Migrations
{
    [Migration(202307071354)]
    public class M202307071354_AdicionarColunaPontosNaTabelaFamilia : Migration
    {
        private const string NomeDaTabela = "Familia";
        private const string NomeDaColuna = "Pontos";
        public override void Up()
        {
            Alter.Table(NomeDaTabela)
                 .AddColumn(NomeDaColuna)
                 .AsInt32()
                 .WithDefaultValue(0)
                 .Nullable();

        }
        public override void Down()
        {
            Delete.Column(NomeDaColuna).FromTable(NomeDaColuna);
        }
    }
}
