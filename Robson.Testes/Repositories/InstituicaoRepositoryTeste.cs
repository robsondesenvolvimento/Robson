using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using System.Threading.Tasks;
using Xunit;

namespace Robson.Testes.Repositories
{
    [TestCaseOrderer("Robson.Testes.PriorityOrderer", "Robson.Testes")]
    public class InstituicaoRepositoryTeste
    {
        private readonly InstituicaoRepository _instituicaoRepository;

        public InstituicaoRepositoryTeste()
        {
            DbContextOptionsBuilder<DatabaseContext> options = new DbContextOptionsBuilder<DatabaseContext>();
            options.UseInMemoryDatabase("InstituicaoRepositoryTeste");
            _instituicaoRepository = new InstituicaoRepository(new(options.Options));
        }

        [Fact, TestPriority(0)]
        public async Task InstituicaoRepositoryIncluir()
        {
            var _instituicaoId = await _instituicaoRepository.IncluirAsync(
                new()
                {
                    Nome = "Alura"
                }
            );

            Assert.Equal(1, _instituicaoId);
        }

        [Fact, TestPriority(1)]
        public async Task InstituicaoRepositoryPesquisarId()
        {
            var pesquisaInstituicao = await _instituicaoRepository.PesquisarIdAsync(1);
            Assert.Equal("Alura", pesquisaInstituicao.Nome);
        }

        [Fact, TestPriority(2)]
        public async Task InstituicaoRepositoryPesquisarNome()
        {
            var pesquisaInstituicao = await _instituicaoRepository.PesquisarAsync(instituicao => instituicao.Nome == "Alura");
            Assert.Equal("Alura", pesquisaInstituicao.Nome);
        }

        [Fact, TestPriority(3)]
        public async Task InstituicaoRepositoryAlterarInstituicao()
        {
            var pesquisaInstituicao = await _instituicaoRepository.PesquisarIdAsync(1);
            pesquisaInstituicao.Nome = "Alura X";

            await _instituicaoRepository.AlterarAsync(pesquisaInstituicao);

            pesquisaInstituicao = await _instituicaoRepository.PesquisarIdAsync(1);
            Assert.Equal("Alura X", pesquisaInstituicao.Nome);
        }

        [Fact, TestPriority(4)]
        public async Task InstituicaoRepositoryExcluirInstituicao()
        {
            await _instituicaoRepository.ExcluirAsync(1);

            var pesquisaInstituicao = await _instituicaoRepository.PesquisarIdAsync(1);
            Assert.Null(pesquisaInstituicao);
        }
    }
}
