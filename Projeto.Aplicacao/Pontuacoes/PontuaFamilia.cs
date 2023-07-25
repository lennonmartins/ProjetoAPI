using AutoMapper;
using Projeto.Aplicacao.DTOs.Responses;
using Projeto.Dominio;

namespace Projeto.Aplicacao.ServicoDePontuacao
{
    public class PontuaFamilia : IPontuaFamilia
    {
        private readonly ValidacaoDeCriteriosAtendidos _validacaoDeCriterios;   
        
        public PontuaFamilia( ValidacaoDeCriteriosAtendidos validacao)
        {
            _validacaoDeCriterios = validacao;
        }

        public Familia PontuarPelosCriteriosAtendidos(Familia familia)
        {
            var familiaPontuada = _validacaoDeCriterios.ObterQuantidadeDePontos(familia);
            return familiaPontuada;
        }
    }
} 
