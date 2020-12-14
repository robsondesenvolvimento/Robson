using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Robson.Testes.Data.InstituicaoRepositoryTeste
{
    public class InstituicaoRepositoryIncluirAsync
    {
        [Fact]
        public async Task IncluirInstituicaoERetornaNovoIdDaInstituicaoIncluida()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var repository = new InstituicaoRepository(new(options));

            var instituicaoId = await repository.IncluirAsync(
                new()
                {
                    Nome = "Alura"
                }
            );

            Assert.Equal(1, instituicaoId);
        }
    }
}
