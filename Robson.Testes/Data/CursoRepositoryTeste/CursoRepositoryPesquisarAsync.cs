using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using Robson.Domain.Entities;
using Robson.Testes.DataBuilder;
using System;
using System.Collections.Generic;
using Xunit;

namespace Robson.Testes.Data.CursoRepositoryTeste
{
    public class InstituicaoRepositoryPesquisarAsync
    {
        [Fact]
        public async void PesquisaPorNomeERetornaCurso()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var repository = new CursoRepository(new(options));

            var listaDeCursos = new CursoBuilder()
                .BuildListState();

            await repository.IncluirListaAsync(listaDeCursos);

            var pesquisaCurso = await repository.PesquisarAsync(curso => curso.Nome == "Curso de Desenvolvimento Asp.Net Core");
            Assert.Equal(2, pesquisaCurso.Id);
        }
    }
}
