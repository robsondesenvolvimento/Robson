using Robson.Repository.Context;
using Robson.Repository.Repositories;
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
            _pessoaRepository = new PessoaRepository(new DatabaseContext());
        }

        [Fact, TestPriority(0)]
        public async Task PessoaRepositoryIncluir()
        {
            var pessoaId = await _pessoaRepository.IncluirAsync(
                new()
                {
                    Nome = "Robson Candido dos Santos Alves",
                    Nascimento = DateTime.Parse("1980-08-29"),
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

            Assert.Equal(1, pessoaId);
        }

        [Fact, TestPriority(1)]
        public async Task PessoaRepositoryPesquisarId()
        {
            var pesquisaPessoa = await _pessoaRepository.PesquisarIdAsync(1);
            Assert.Equal("Robson Candido dos Santos Alves", pesquisaPessoa.Nome);
        }

        [Fact, TestPriority(2)]
        public async Task PessoaRepositoryPesquisarNome()
        {
            var pesquisaPessoa = await _pessoaRepository.PesquisarAsync(pessoa => pessoa.Nome == "Robson Candido dos Santos Alves");
            Assert.Equal("Robson Candido dos Santos Alves", pesquisaPessoa.Nome);
        }

        [Fact, TestPriority(3)]
        public async Task PessoaRepositoryAlterarPessoa()
        {
            var pesquisaPessoa = await _pessoaRepository.PesquisarIdAsync(1);
            pesquisaPessoa.Nome = "Robson Alves";

            await _pessoaRepository.AlterarAsync(pesquisaPessoa);

            pesquisaPessoa = await _pessoaRepository.PesquisarIdAsync(1);
            Assert.Equal("Robson Alves", pesquisaPessoa.Nome);
        }

        [Fact, TestPriority(4)]
        public async Task PessoaRepositoryExcluirPessoa()
        {
            await _pessoaRepository.ExcluirAsync(1);

            var pesquisaPessoa = await _pessoaRepository.PesquisarIdAsync(1);
            Assert.Null(pesquisaPessoa);
        }
    }
}
