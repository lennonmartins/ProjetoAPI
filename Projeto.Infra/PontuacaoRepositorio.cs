using NHibernate;
using Projeto.Dominio;

namespace Projeto.Infra
{
    public class PontuacaoRepositorio
    {
        private readonly ISession _session;

        public PontuacaoRepositorio(ISession session)
        {
            _session = session;
        }

        public void Cadastrar(Pontuacao pontuacao)
        {
            using var transacao =  _session.BeginTransaction();
            _session.Save(pontuacao);
            transacao.Commit();
        }

        public Pontuacao ObterPeloId(int idFamila)
        {
            var pontuacao = _session.Query<Pontuacao>().Join(
                    _session.Query<FamiliaPontuacao>(),
                    p => p.Id,
                    pf => pf.Pontuacao.Id,
                    (p, pf) => new { Pontuacao = p, FamiliaPontuacao = pf })
                .Where(joinResult => joinResult.FamiliaPontuacao.Familia.Id == idFamila)
                .Select(joinResult => joinResult.Pontuacao)
                .Single();

            return pontuacao;
        }
    }
}
