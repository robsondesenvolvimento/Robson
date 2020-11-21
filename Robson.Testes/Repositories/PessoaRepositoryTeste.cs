using Robson.Domain.Entities;
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
            var pessoa = new Pessoa
            {
                Nome = "Robson Candido dos Santos Alves",
                Nascimento = DateTime.Parse("1980-08-29")
            };

            var pessoaId = await _pessoaRepository.Incluir(pessoa);
            Assert.Equal(1, pessoaId);
        }

        [Fact, TestPriority(1)]
        public async Task PessoaRepositoryPesquisa()
        {
            var pesquisaPessoa = await _pessoaRepository.PesquisaId(1);
            Assert.Equal("Robson Candido dos Santos Alves", pesquisaPessoa.Nome);
        }
    }
}
