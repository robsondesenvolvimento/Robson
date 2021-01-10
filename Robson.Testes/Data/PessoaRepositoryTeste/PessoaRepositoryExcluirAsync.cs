using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using Robson.Testes.DataBuilder;
using System;
using Xunit;

namespace Robson.Testes.Data.PessoaRepositoryTeste
{
    public class PessoaRepositoryExcluirAsync
    {
        [Fact]
        public async void ExcluirPessoa()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var repository = new PessoaRepository(new(options));

            var pessoasBuilder = new PessoaBuilder()
                .BuildListState();

            await repository.IncluirListaAsync(pessoasBuilder);

            await repository.ExcluirAsync(1);

            var pesquisaPessoa = await repository.PesquisarIdAsync(1);

            Assert.Null(pesquisaPessoa);
        }
    }
}
