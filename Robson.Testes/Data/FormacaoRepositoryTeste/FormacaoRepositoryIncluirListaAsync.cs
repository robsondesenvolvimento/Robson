using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using Robson.Testes.DataBuilder;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Robson.Testes.Data.FormacaoRepositoryTeste
{
    public class FormacaoRepositoryIncluirListaAsync
    {
        [Fact]
        public async Task IncluirListaDeFormacoesERetornaVerdadeiroSeFormacoesInseridos()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var repository = new FormacaoRepository(new(options));

            var listaDeFormacoes = new FormacaoBuilder()
                .BuildListState();

            var formacoesIncluidas = await repository.IncluirListaAsync(listaDeFormacoes);

            Assert.True(formacoesIncluidas);
        }
    }
}
