using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using Robson.Testes.DataBuilder;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Robson.Testes.Data.FormacaoRepositoryTeste
{
    public class FormacaoRepositoryTodos
    {
        [Fact]
        public async Task RetornaListaDeTodoAsFormacoes()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var repository = new FormacaoRepository(new(options));

            var listaDeFormacoes = new FormacaoBuilder()
                .BuildListState();

            await repository.IncluirListaAsync(listaDeFormacoes);

            var totalDeRegistrosInseridos = await repository.Todos();

            Assert.True(totalDeRegistrosInseridos.ToList().Count > 1);
        }
    }
}
