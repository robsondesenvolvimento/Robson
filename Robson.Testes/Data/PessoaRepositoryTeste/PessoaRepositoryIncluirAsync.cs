using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using Robson.Testes.DataBuilder;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Robson.Testes.Data.PessoaRepositoryTeste
{
    public class CarreiraRepositoryIncluirAsync
    {
        [Fact]
        public async Task IncluirPessoaERetornaNovoIdDaPessoaIncluida()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var repository = new PessoaRepository(new(options));

            var pessoaBuilder = new PessoaBuilder();
            pessoaBuilder.BuildSingleState();

            var pessoaId = await repository.IncluirAsync(pessoaBuilder.Pessoa());

            Assert.Equal(1, pessoaId);
        }
    }
}
