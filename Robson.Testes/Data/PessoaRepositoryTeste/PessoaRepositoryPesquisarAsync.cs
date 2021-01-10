using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using Robson.Testes.DataBuilder;
using System;
using Xunit;

namespace Robson.Testes.Data.PessoaRepositoryTeste
{
    public class PessoaRepositoryPesquisarAsync
    {
        [Fact]
        public async void PesquisaPorNomeERetornaPessoa()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var repository = new PessoaRepository(new(options));

            var pessoasBuilder = new PessoaBuilder()
                .BuildListState();

            await repository.IncluirListaAsync(pessoasBuilder);

            var pesquisaPessoa = await repository.PesquisarAsync(pessoa => pessoa.Nome == "Henrique Casagrande dos Santos Alves");
            Assert.Equal(2, pesquisaPessoa.Id);
        }
    }
}
