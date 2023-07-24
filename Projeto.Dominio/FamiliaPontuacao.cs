namespace Projeto.Dominio
{
    public class FamiliaPontuacao
    {
        private int _id;
        public virtual int Id { get { return _id; } }
        public virtual int FamiliaId { get; set; }
        public virtual int PontuacaoId { get; set; }
        public virtual Familia Familia { get; set; }
        public virtual Pontuacao Pontuacao { get; set; }
    }
}
