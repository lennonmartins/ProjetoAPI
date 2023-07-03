using FluentMigrator;

namespace Projeto.Infra.Migrations
{
    [Migration(202307031037)]
    public class M202307031037_CriarTabelaFamilia : Migration
    {
        private readonly string NomeDaTabela = "Familia";

        public override void Up()
        {
            Create.Table(NomeDaTabela)
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("NomeDoResponsavel").AsString().NotNullable()
                .WithColumn("Telefone").AsString(15).NotNullable()
                .WithColumn("Cpf_responsavel").AsString(11).NotNullable()
                .WithColumn("RendaTotaldaFamilia").AsDecimal()
                .WithColumn("QuantidadeDeDependentes").AsInt32();

        }
        public override void Down()
        {
            Delete.Table(NomeDaTabela);
        }
    }
}
