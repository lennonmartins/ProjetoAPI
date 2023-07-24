using FluentMigrator;

namespace Projeto.Infra.Migrations
{
    [Migration(202307241740)]
    public class M202307241740_CriarTabelaPontuacao : Migration
    {
        private readonly string NomeDaTabela = "Pontuacao";
        private readonly string NomeDaColuna = "IdPontuacao";
        public override void Up()
        {
            /*Create.Table(NomeDaTabela)
                .WithColumn(NomeDaColuna).AsInt32().PrimaryKey().Identity()
                .WithColumn("Pontuacao").AsInt32().Nullable()
                .WithColumn("RegistroPontuacao").AsDateTime();*/

            Create.Table("FamiliaPontuacao")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("FamiliaId").AsInt32().NotNullable()
                .WithColumn("PontuacaoId").AsInt32().NotNullable();

            Create.ForeignKey("FK_PontuacaoFamilia_FamiliaId")
                .FromTable("FamiliaPontuacao").ForeignColumn("FamiliaId")
                .ToTable("Familia").PrimaryColumn("Id");

            Create.ForeignKey("FK_PontuacaoFamilia_PontuacaoId")
                .FromTable("FamiliaPontuacao").ForeignColumn("PontuacaoId")
                .ToTable("Pontuacao").PrimaryColumn(NomeDaColuna);

        }

        public override void Down()
        {
            Delete.ForeignKey("FK_PontuacaoFamilia_FamiliaId").OnTable("FamiliaPontuacao");
            Delete.ForeignKey("FK_PontuacaoFamilia_PontuacaoId").OnTable("FamiliaPontuacao");
            Delete.Table("FamiliaPontuacao");
            Delete.Table(NomeDaTabela);
            Alter.Table("Familia")
                 .AddColumn("Pontos")
                 .AsInt32()
                 .WithDefaultValue(0)
                 .Nullable();
        }
    }
}
