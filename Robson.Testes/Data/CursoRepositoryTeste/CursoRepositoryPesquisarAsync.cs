using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using Robson.Domain.Entities;
using System;
using System.Collections.Generic;
using Xunit;

namespace Robson.Testes.Data.CursoRepositoryTeste
{
    public class CursoRepositoryPesquisarAsync
    {
        [Fact]
        public async void PesquisaPorNomeERetornaCurso()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var repository = new CursoRepository(new(options));

            var listaDeCursos = new List<Curso>
            {
                new()
                {
                    Nome = "Curso de Desenvolvimento C#",
                    Descricao = "Curso de Desenvolvimento C#",
                    InstituicaoId = 1,
                    DataConclusao = DateTime.Parse("2020-12-12")
                },
                new()
                {
                    Nome = "Curso de Desenvolvimento Asp.Net Core",
                    Descricao = "Curso de Desenvolvimento Asp.Net Core",
                    InstituicaoId = 1,
                    DataConclusao = DateTime.Parse("2020-11-12")
                },
                new()
                {
                    Nome = "Curso de Desenvolvimento C++",
                    Descricao = "Curso de Desenvolvimento C++",
                    InstituicaoId = 1,
                    DataConclusao = DateTime.Parse("2020-11-12")
                }
            };

            await repository.IncluirListaAsync(listaDeCursos);

            var pesquisaCurso = await repository.PesquisarAsync(curso => curso.Nome == "Curso de Desenvolvimento Asp.Net Core");
            Assert.Equal(2, pesquisaCurso.Id);
        }
    }
}
