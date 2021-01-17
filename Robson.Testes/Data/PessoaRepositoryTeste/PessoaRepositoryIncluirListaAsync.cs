using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using Robson.Testes.DataBuilder;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Robson.Testes.Data.PessoaRepositoryTeste
{
    public class PessoaRepositoryIncluirListaAsync
    {
        [Fact]
        public async Task IncluirListaDePessoasERetornaVerdadeiroSeRegistrosInseridos()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var repository = new PessoaRepository(new(options));

            var pessoasBuilder = new PessoaBuilder()
                .BuildListState();

            var pessoasIncluidas = await repository.IncluirListaAsync(pessoasBuilder);

            Assert.True(pessoasIncluidas);
        }
    }
}
