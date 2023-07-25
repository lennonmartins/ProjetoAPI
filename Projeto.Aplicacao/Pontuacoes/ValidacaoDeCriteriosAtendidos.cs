﻿using Projeto.Dominio.Familias;

namespace Projeto.Aplicacao.ServicoDePontuacao
{
    public class ValidacaoDeCriteriosAtendidos
    {
       private readonly GerenciadorDeCriterios _criterios;
       
       public ValidacaoDeCriteriosAtendidos(GerenciadorDeCriterios criterios)
        {
            _criterios = criterios;
        }

        public Familia ObterQuantidadeDePontos(Familia familia)
        {
            var criterios = _criterios.ObterCriterioSetados();
            foreach ( var criterio in criterios)
            {
                criterio.ValidarCriteriosAtendidos(familia);
            }

            return familia;
        }
    }
}
