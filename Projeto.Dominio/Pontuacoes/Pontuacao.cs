using Projeto.Dominio.Familias;

namespace Projeto.Dominio.Pontuacoes
{
    public class Pontuacao
    {
        public virtual int Id { get; protected set; }
        public virtual int Pontos { get; protected set; }
        public virtual DateTime DataDeRegistroDaSolicitacao { get; protected set; }
       /* public virtual Familia Familia { get; protected set; }*/

        protected Pontuacao() { }
        public Pontuacao(int pontos)
        {
            Pontos = pontos;
            DataDeRegistroDaSolicitacao = DateTime.Now;
        }
    }
}
