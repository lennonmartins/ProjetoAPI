using FluentNHibernate.Mapping;
using Projeto.Dominio;

namespace Projeto.Infra
{
    public class PontuacaoMap : ClassMap<Pontuacao>
    {
        public PontuacaoMap() 
        {
            Id(pontuacao => pontuacao.Id)
                .GeneratedBy.Identity()
                .UnsavedValue(0)
                .Access.CamelCaseField(Prefix.Underscore);

            Map(pontuacao => pontuacao.Pontos);
            Map(pontuacao => pontuacao.DataDeSolicitacaoDePontos);
        }
    }
}
