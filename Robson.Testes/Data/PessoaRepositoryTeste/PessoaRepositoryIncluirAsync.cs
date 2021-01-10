using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using Robson.Testes.DataBuilder;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Robson.Testes.Data.PessoaRepositoryTeste
{
    public class PessoaRepositoryIncluirAsync
    {
        [Fact]
        public async Task IncluirPessoaERetornaNovoIdDaPessoaIncluida()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var repository = new PessoaRepository(new(options));

            var pessoaBuilder = new PessoaBuilder()
                .BuildSingleState();

            var pessoaId = await repository.IncluirAsync(pessoaBuilder);

            Assert.Equal(1, pessoaId);
        }
    }
}
