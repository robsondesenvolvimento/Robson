using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using Robson.Testes.DataBuilder;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Robson.Testes.Data.CursoRepositoryTeste
{
    public class InstituicaoRepositoryIncluirListaAsync
    {
        [Fact]
        public async Task IncluirListaDeCursosERetornaTotalDeRegistrosInseridos()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var repository = new CursoRepository(new(options));

            var listaDeCursos = new CursoBuilder()
                .BuildListState();

            var totalDeRegistrosInseridos = await repository.IncluirListaAsync(listaDeCursos);

            Assert.Equal(3, totalDeRegistrosInseridos);
        }
    }
}
