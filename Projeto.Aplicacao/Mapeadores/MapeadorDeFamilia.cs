﻿using Projeto.Dominio;
using Projeto.Aplicacao.DTOs;

namespace Projeto.WebApi.Mapeadores
{
    public class MapeadorDeFamilia
    {
        public static Familia MapearFamiliaRequest(FamiliaRequestDto familiaRequestDto)
        {
            return new Familia(familiaRequestDto.NomeDoResponsavel, familiaRequestDto.Telefone, familiaRequestDto.CPF, familiaRequestDto.RendaTotalDaFamilia, familiaRequestDto.QuantidadeDeDependentes);
        }
    }
}
