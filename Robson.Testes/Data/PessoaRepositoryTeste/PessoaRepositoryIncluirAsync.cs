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
        public async Task IncluirPessoaERetornaNovoIdDaPessoaIncluidaEVerdadeiroSepessoaIncluida()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var repository = new PessoaRepository(new(options));

            var pessoaBuilder = new PessoaBuilder()
                .BuildSingleState();

            var pessoaIncluida = await repository.IncluirAsync(pessoaBuilder);

            Assert.Equal(1, pessoaBuilder.Id);
            Assert.True(pessoaIncluida);
        }
    }
}
