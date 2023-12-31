﻿using NUnit.Framework;
using Projeto.Dominio.Familias;
using Projeto.Dominio.Pontuacoes;
using Projeto.TestesDeUnidade.Dominio.Builder;

namespace Projeto.TestesDeUnidade.Dominio
{
    [TestFixture]
    public class FamiliaTeste
    {
        [Test]
        public void Deve_criar_uma_familia()
        {
            var nomeResponsavelEsperado = "Lennon Martins";
            var cpf = "01756232288";
            var telefone = "67981313178";
            decimal rendaTotalFamilia = 1500;
            int quantidadeDeDependentes = 2;

            var familiaCriada = new Familia(nomeResponsavelEsperado, cpf, telefone, rendaTotalFamilia, quantidadeDeDependentes);

            Assert.AreEqual(familiaCriada.NomeDoResponsavel, nomeResponsavelEsperado);
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Nao_deve_criar_uma_familia_sem_cpf_do_reponsavel(string cpfNuloOuVazio)
        {
            TestDelegate familiaEsperada =  () => new FamiliaBuilder().ComCpf(cpfNuloOuVazio).Criar();

            Assert.Throws<ArgumentException>(familiaEsperada);
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Nao_deve_criar_uma_familia_sem_contato_do_responsavel(string telefoneNuloOuVazio)
        {
            TestDelegate familiaEsperada = () => new FamiliaBuilder().ComTelefone(telefoneNuloOuVazio).Criar();

            Assert.Throws<ArgumentException>(familiaEsperada);
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Nao_deve_criar_uma_familia_sem_nome_do_responsavel(string nomeNuloOuVazio)
        {
            TestDelegate familiaEsperada = () => new FamiliaBuilder().ComResponsavel(nomeNuloOuVazio).Criar();

            Assert.Throws<ArgumentException>(familiaEsperada);
        }

        [Test]
        public void Deve_adicionar_pontos_a_familia()
        {
            int pontosEsperados = 5;
            var familiaCriada = new FamiliaBuilder().Criar();
            var pontuacao = new Pontuacao(pontosEsperados);

            familiaCriada.AdiconarPontucao(pontuacao);

            Assert.AreEqual(pontosEsperados, familiaCriada.Pontos.Last().Pontos);
        }

        [Test]
        public void Deve_alterar_uma_familia()
        {
            var nomeResponsavelParaAlterar = "Lennon Martins";
            var familia = new FamiliaBuilder().Criar();
            var familiaComResponsavelAlterada = new FamiliaBuilder().ComResponsavel(nomeResponsavelParaAlterar).Criar();

            familia.AlterarFamilia(familiaComResponsavelAlterada);

            Assert.AreEqual(nomeResponsavelParaAlterar, familia.NomeDoResponsavel);
        }
    }
}
