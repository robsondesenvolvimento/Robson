using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using Robson.Testes.DataBuilder;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Robson.Testes.Data.CursoRepositoryTeste
{
    public class InstituicaoRepositoryTodos
    {
        [Fact]
        public async Task RetornaListaDeTodoOsCursos()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var repository = new CursoRepository(new(options));

            var listaDeCursos = new CursoBuilder()
                .BuildListState();

            await repository.IncluirListaAsync(listaDeCursos);

            var totalDeRegistrosInseridos = await repository.Todos();

            Assert.True(totalDeRegistrosInseridos.ToList().Count > 1);
        }
    }
}
