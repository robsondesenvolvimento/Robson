using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using Robson.Testes.DataBuilder;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Robson.Testes.Data.InstituicaoRepositoryTeste
{
    public class InstituicaoRepositoryIncluirAsync
    {
        [Fact]
        public async Task IncluirInstituicaoERetornaNovoIdDaInstituicaoIncluidaEVerdadeiroSeInstituicoesIncluidas()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var repository = new InstituicaoRepository(new(options));

            var instituicao = new InstituicaoBuilder()
                .BuildSingleState();

            var instituicaoIncluida = await repository.IncluirAsync(instituicao);

            Assert.Equal(1, instituicao.Id);
            Assert.True(instituicaoIncluida);
        }
    }
}
