using Projeto.Dominio;

namespace Projeto.Aplicacao.Servicos
{
    public class Criterios
    {
        private List<IValidaCriteriosAtendidos> validacoes;
        public void SetarCriterios(List<IValidaCriteriosAtendidos> validaCriteriosAtendidos) {
            validacoes = validaCriteriosAtendidos;
        }

        public void Resultado(Familia familia)
        {
            foreach ( var criterio in validacoes )
            {
                criterio.ValidarCriteriosAtendidos(familia);
            }
        }
    }
}
