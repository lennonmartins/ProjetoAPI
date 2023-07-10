namespace Projeto.Dominio
{
    public interface IFamiliaRepositorio
    {
        void SalvarNovaFamilia(Familia familia);
        Familia? BuscarFamiliaPeloCpfDoResponsavel(string cpf);
       
    }
}
