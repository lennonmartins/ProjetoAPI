namespace Projeto.Dominio.Pontuacoes
{
    public class Pontuacao
    {
        private int _id; // Alterar para Id apenas
        public virtual int Id { get { return _id; } }
        public virtual int Pontos { get; protected set; }
        public virtual DateTime DataDeRegistroDaSolicitacao { get; protected set; }

        public Pontuacao(int pontos)
        {
            Pontos = pontos;
            DataDeRegistroDaSolicitacao = DateTime.Now;
        }

        public virtual void AdicionarPontos(int pontos)
        {
            Pontos += pontos;
        }
    }
}
