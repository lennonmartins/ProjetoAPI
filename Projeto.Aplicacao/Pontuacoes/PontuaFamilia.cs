using AutoMapper;
using Projeto.Aplicacao.Familias;
using Projeto.Dominio;

namespace Projeto.Aplicacao.ServicoDePontuacao
{
    public class PontuaFamilia : IPontuaFamilia
    {
       
        private readonly ValidacaoDeCriteriosAtendidos _validacaoDeCriterios;
   
    
        public PontuaFamilia(ValidacaoDeCriteriosAtendidos validacao)
        {
            _validacaoDeCriterios = validacao;
        }

        public Familia PontuarPelosCriteriosAtendidos(Familia familia, Pontuacao pontuacao)
        {
            var familiaPontuada = _validacaoDeCriterios.ObterQuantidadeDePontos(familia,pontuacao);
            return familiaPontuada;
        }
    }
} 
