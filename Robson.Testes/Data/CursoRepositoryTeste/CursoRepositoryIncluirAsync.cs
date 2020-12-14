using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Robson.Testes.Data.CursoRepositoryTeste
{
    public class InstituicaoRepositoryIncluirAsync
    {
        [Fact]
        public async Task IncluirCursosERetornaNovoIdDoCursoIncluido()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var repository = new CursoRepository(new(options));

            var cursoId = await repository.IncluirAsync(
                new()
                {
                    Nome = "Curso de Desenvolvimento C#",
                    Descricao = "Curso de Desenvolvimento C#",
                    InstituicaoId = 1,
                    DataConclusao = DateTime.Parse("2020-12-12")
                }
            );

            Assert.Equal(1, cursoId);
        }
    }
}
