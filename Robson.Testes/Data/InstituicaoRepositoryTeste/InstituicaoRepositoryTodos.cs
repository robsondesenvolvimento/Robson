using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using Robson.Testes.DataBuilder;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Robson.Testes.Data.InstituicaoRepositoryTeste
{
    public class InstituicaoRepositoryTodos
    {
        [Fact]
        public async Task RetornaListaDeTodoAsInstituicoes()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var repository = new InstituicaoRepository(new(options));

            var instituicoes = new InstituicaoBuilder()
                .BuildListState();

            await repository.IncluirListaAsync(instituicoes);

            var totalDeRegistrosInseridos = await repository.Todos();

            Assert.True(totalDeRegistrosInseridos.ToList().Count > 1);
        }
    }
}
