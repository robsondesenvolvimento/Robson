using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Robson.Testes.Repositories
{
    [TestCaseOrderer("Robson.Testes.PriorityOrderer", "Robson.Testes")]
    public class PessoaRepositoryTeste
    {
        private readonly PessoaRepository _pessoaRepository;

        public PessoaRepositoryTeste()
        {
            DbContextOptionsBuilder<DatabaseContext> options = new DbContextOptionsBuilder<DatabaseContext>();
            options.UseInMemoryDatabase("PessoaRepositoryTeste");
            _pessoaRepository = new PessoaRepository(new(options.Options));
        }

        [Fact, TestPriority(1)]
        public async Task PessoaRepositoryIncluir()
        {
            var _pessoaId = await _pessoaRepository.IncluirAsync(
                new()
                {
                    Nome = "Teste de Unidade Pessoa",
                    Nascimento = DateTime.Parse("2019-07-21"),
                    Celular = "(41) 98827-07693",
                    Cep = "80050-205",
                    Rua = "Rua Do Herval, 378",
                    Complemento = "Apto. 3",
                    Bairro = "Cristo Rei",
                    Cidade = "Curitiba",
                    Estado = "Paraná",
                    Pais = "Brasil"
                }
            );

            Assert.Equal(1, _pessoaId);
        }

        [Fact, TestPriority(2)]
        public async Task PessoaRepositoryPesquisarId()
        {
            var pesquisaPessoa = await _pessoaRepository.PesquisarIdAsync(1);
            Assert.Equal("Teste de Unidade Pessoa", pesquisaPessoa.Nome);
        }

        [Fact, TestPriority(3)]
        public async Task PessoaRepositoryPesquisarNome()
        {
            var pesquisaPessoa = await _pessoaRepository.PesquisarAsync(pessoa => pessoa.Nome == "Teste de Unidade Pessoa");
            Assert.Equal("Teste de Unidade Pessoa", pesquisaPessoa.Nome);
        }

        [Fact, TestPriority(4)]
        public async Task PessoaRepositoryAlterarPessoa()
        {
            var pesquisaPessoa = await _pessoaRepository.PesquisarIdAsync(1);
            pesquisaPessoa.Nome = "Teste de Unidade Pessoa X";

            await _pessoaRepository.AlterarAsync(pesquisaPessoa);

            pesquisaPessoa = await _pessoaRepository.PesquisarIdAsync(1);
            Assert.Equal("Teste de Unidade Pessoa X", pesquisaPessoa.Nome);
        }

        [Fact, TestPriority(5)]
        public async Task PessoaRepositoryExcluirPessoa()
        {
            await _pessoaRepository.ExcluirAsync(1);

            var pesquisaPessoa = await _pessoaRepository.PesquisarIdAsync(1);
            Assert.Null(pesquisaPessoa);
        }
    }
}
