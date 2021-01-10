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
    public class InstituicaoRepositoryAlterarAsync
    {
        [Fact]
        public async void AlteraDadosDoCurso()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var repository = new CursoRepository(new(options));

            var listaDeCursos = new CursoBuilder()
                .BuildListState();

            await repository.IncluirListaAsync(listaDeCursos);

            var pesquisaCurso = await repository.PesquisarIdAsync(2);

            pesquisaCurso.Nome = "Curso de Desenvolvimento Asp.Net Core X";

            await repository.AlterarAsync(pesquisaCurso);

            pesquisaCurso = await repository.PesquisarIdAsync(2);

            Assert.Equal("Curso de Desenvolvimento Asp.Net Core X", pesquisaCurso.Nome);
        }
    }
}
