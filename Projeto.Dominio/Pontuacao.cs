namespace Projeto.Dominio
{
    public class Pontuacao
    {
        private int _id;
        public virtual int Id { get { return _id; } }
        public virtual int Pontos { get; protected set; }
        public virtual DateTime DataDeSolicitacaoDePontos { get; protected set; }

        public Pontuacao() { }  
        public Pontuacao(int pontuacao)
        {
            Pontos = pontuacao;
            DataDeSolicitacaoDePontos = DateTime.Now;
        }

        public virtual int AdicionarPontos(int pontos)
        {
            return Pontos + pontos;
        }
    }
}
