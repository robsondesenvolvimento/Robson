using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using Robson.Domain.Entities;
using Robson.Testes.DataBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Robson.Testes.Data.PessoaRepositoryTeste
{
    public class PessoaRepositoryTodos
    {
        [Fact]
        public async Task RetornaListaDeTodasAsPessoas()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var repository = new PessoaRepository(new(options));

            var pessoasBuilder = new PessoaBuilder()
                .BuildListState();

            await repository.IncluirListaAsync(pessoasBuilder);

            var totalDeRegistrosInseridos = await repository.Todos();

            Assert.True(totalDeRegistrosInseridos.ToList().Count > 1);
        }
    }
}
