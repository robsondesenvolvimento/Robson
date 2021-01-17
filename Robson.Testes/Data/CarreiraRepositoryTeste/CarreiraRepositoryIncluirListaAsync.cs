using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using Robson.Testes.DataBuilder;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Robson.Testes.Data.CarreiraRepositoryTeste
{
    public class CursoRepositoryIncluirListaAsync
    {
        [Fact]
        public async Task IncluirListaDeCarreirasERetornaVerdadeiroSeCarreirasInseridas()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var repository = new CarreiraRepository(new(options));

            var listaDeCarreiras = new CarreiraBuilder()
                .BuildListState();

            var cursosIncluidos = await repository.IncluirListaAsync(listaDeCarreiras);

            Assert.True(cursosIncluidos);
        }
    }
}
