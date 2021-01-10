using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using Robson.Testes.DataBuilder;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Robson.Testes.Data.InstituicaoRepositoryTeste
{
    public class InstituicaoRepositoryIncluirListaAsync
    {
        [Fact]
        public async Task IncluirListaDeInstituicoesERetornaTotalDeRegistrosInseridos()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var repository = new InstituicaoRepository(new(options));

            var instituicoes = new InstituicaoBuilder()
                .BuildListState();

            var totalDeRegistrosInseridos = await repository.IncluirListaAsync(instituicoes);

            Assert.Equal(2, totalDeRegistrosInseridos);
        }
    }
}
