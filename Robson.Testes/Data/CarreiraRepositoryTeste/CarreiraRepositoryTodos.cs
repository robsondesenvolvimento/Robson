using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using Robson.Testes.DataBuilder;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Robson.Testes.Data.CarreiraRepositoryTeste
{
    public class CursoRepositoryTodos
    {
        [Fact]
        public async Task RetornaListaDeTodasAsCarreiras()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var repository = new CarreiraRepository(new(options));

            var listaDeCarreiras = new CarreiraBuilder()
                .BuildListState();

            await repository.IncluirListaAsync(listaDeCarreiras);

            var totalDeRegistrosInseridos = await repository.Todos();

            Assert.True(totalDeRegistrosInseridos.ToList().Count > 1);
        }
    }
}
