using FluentNHibernate.Mapping;
using Projeto.Dominio;

namespace Projeto.Infra
{
    public  class FamiliaPontuacaoMap : ClassMap<FamiliaPontuacao>
    {
        public FamiliaPontuacaoMap()
        {
            Id(familiaPontuacao  => familiaPontuacao.Id)
                .GeneratedBy.Identity()
                .UnsavedValue(0)
                .Access.CamelCaseField(Prefix.Underscore);
            Map(familiaPontuacao => familiaPontuacao.Pontuacao);
            Map(familiaPontuacao => familiaPontuacao.PontuacaoId);
            Map(familiaPontuacao => familiaPontuacao.Familia);
            Map(familiaPontuacao => familiaPontuacao.FamiliaId);           
        }
    }
}
