using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using Robson.Testes.DataBuilder;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Robson.Testes.Data.CursoRepositoryTeste
{
    public class InstituicaoRepositoryIncluirAsync
    {
        [Fact]
        public async Task IncluirCursosERetornaNovoIdDoCursoIncluidoEVerdadeiroSeCursoIncluido()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var repository = new CursoRepository(new(options));

            var cursoBuilder = new CursoBuilder()
                .BuildSingleState();

            var instituicaoIncluida = await repository.IncluirAsync(cursoBuilder);

            Assert.Equal(1, cursoBuilder.Id);
            Assert.True(instituicaoIncluida);
        }
    }
}
