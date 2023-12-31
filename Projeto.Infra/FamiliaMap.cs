﻿using FluentNHibernate.Mapping;
using Projeto.Dominio.Familias;

namespace Projeto.Infra
{
    public class FamiliaMap : ClassMap<Familia>
    {
        public FamiliaMap() 
        {
            Id(familia => familia.Id)
                .GeneratedBy.Identity()
                .UnsavedValue(0);
            
            Map(familia => familia.NomeDoResponsavel);
            Map(familia => familia.Telefone);
            Map(familia => familia.Cpf_responsavel);
            Map(familia => familia.RendaTotalDaFamilia);
            Map(familia => familia.QuantidadeDeDependentes);
            HasMany(familia => familia.Pontos)
                .Access.CamelCaseField(Prefix.Underscore)
                .KeyColumn("idFamilia")
                .Cascade.All()
                .Inverse()
                .LazyLoad();
        }
    }
}
