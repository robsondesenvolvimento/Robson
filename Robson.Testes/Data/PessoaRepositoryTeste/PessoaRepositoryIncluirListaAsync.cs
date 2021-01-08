using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using Robson.Domain.Entities;
using Robson.Testes.DataBuilder;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Robson.Testes.Data.PessoaRepositoryTeste
{
    public class CarreiraRepositoryIncluirListaAsync
    {
        [Fact]
        public async Task IncluirListaDePessoasERetornaTotalDeRegistrosInseridos()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var repository = new PessoaRepository(new(options));

            var pessoaBuilder = new PessoaBuilder();
            pessoaBuilder.BuildListState();

            var totalDeRegistrosInseridos = await repository.IncluirListaAsync(pessoaBuilder.Pessoas());

            Assert.Equal(4, totalDeRegistrosInseridos);
        }
    }
}
