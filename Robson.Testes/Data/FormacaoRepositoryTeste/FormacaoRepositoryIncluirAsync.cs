using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using Robson.Testes.DataBuilder;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Robson.Testes.Data.FormacaoRepositoryTeste
{
    public class FormacaoRepositoryIncluirAsync
    {
        [Fact]
        public async Task IncluirFormacaoERetornaNovoIdDaFormacaoIncluidaEVerdadeiroSeFormacoesIncluidas()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var repository = new FormacaoRepository(new(options));

            var formacao = new FormacaoBuilder()
                .BuildSingleState();

            var formacaoIncluida = await repository.IncluirAsync(formacao);

            Assert.Equal(1, formacao.Id);
            Assert.True(formacaoIncluida);
        }
    }
}
