using Projeto.Dominio.Familias;

namespace Projeto.Aplicacao.Familias
{
    public class RemoveFamilia
    {
        private readonly IFamiliaRepositorio _familiaRepositorio;

        public RemoveFamilia(IFamiliaRepositorio familiaRepositorio)
        {
            _familiaRepositorio = familiaRepositorio;
        }
        public void Remover(int id)
        {
            var familiaObtida = _familiaRepositorio.ObterPor(id);
            _familiaRepositorio.Remover(familiaObtida);
        }
    }
}
