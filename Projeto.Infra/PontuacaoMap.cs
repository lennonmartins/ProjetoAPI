using FluentNHibernate.Mapping;
using Projeto.Dominio.Pontuacoes;

namespace Projeto.Infra
{
    public class PontuacaoMap : ClassMap<Pontuacao>
    {
        PontuacaoMap()
        {
            Id(pontuacao => pontuacao.Id)
                .GeneratedBy.Identity()
                .UnsavedValue(0)
                .Column("IdPontuacao");

            Map(pontuacao => pontuacao.Pontos).Column("Pontuacao");
            Map(pontuacao => pontuacao.DataDeRegistroDaSolicitacao).Column("RegistroPontuacao");
           /* Map(pontuacao => pontuacao.Familia)
                .Column("idFamilia")
                .Cascade.None()
                .LazyLoad();*/
        }
    }
}
