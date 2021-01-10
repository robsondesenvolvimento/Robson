using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using Robson.Testes.DataBuilder;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Robson.Testes.Data.CursoRepositoryTeste
{
    public class InstituicaoRepositoryPesquisarIdAsync
    {
        [Fact]
        public async Task PesquisarPorIdERetornaCurso()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var repository = new CursoRepository(new(options));

            var listaDeCursos = new CursoBuilder()
                .BuildListState();

            await repository.IncluirListaAsync(listaDeCursos);

            var buscaCurso = await repository.PesquisarIdAsync(2);
            Assert.Equal("Curso de Desenvolvimento Asp.Net Core", buscaCurso.Nome);
        }
    }
}
