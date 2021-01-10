using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using Robson.Testes.DataBuilder;
using System;
using Xunit;

namespace Robson.Testes.Data.CursoRepositoryTeste
{
    public class InstituicaoRepositoryExcluirAsync
    {
        [Fact]
        public async void ExcluirCurso()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var repository = new CursoRepository(new(options));

            var listaDeCursos = new CursoBuilder()
                .BuildListState();

            await repository.IncluirListaAsync(listaDeCursos);

            await repository.ExcluirAsync(1);

            var pesquisaCurso = await repository.PesquisarIdAsync(1);

            Assert.Null(pesquisaCurso);
        }
    }
}
