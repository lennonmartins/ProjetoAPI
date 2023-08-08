using FluentMigrator;

namespace Projeto.Infra.Migrations
{
    [Migration(202307251536)]
    public class M202307251536_CriarTabelaPontucao : Migration
    {
        private readonly string NomeDaTabela = "Pontuacao";
        private readonly string ColunaId = "IdPontuacao";
        private readonly string ColunaPontuacao = "Pontuacao";
        private readonly string ColunaRegistro = "RegistroPontuacao";
        private readonly string ColunaIdFamilia = "IdFamilia";

        public override void Up()
        {
            Create.Table(NomeDaTabela)
                    .WithColumn(ColunaId).AsInt32().PrimaryKey().Identity()
                    .WithColumn(ColunaPontuacao).AsInt32().Nullable()
                    .WithColumn(ColunaRegistro).AsDateTime()
                    .WithColumn(ColunaIdFamilia).AsInt32();

            Create.ForeignKey("FK_Pontuacao_FamiliaId")
                .FromTable(NomeDaTabela).ForeignColumn(ColunaIdFamilia)
                .ToTable("Familia").PrimaryColumn("Id");
        }
        public override void Down()
        {
            Delete.Table(NomeDaTabela);
        }
    }
}
