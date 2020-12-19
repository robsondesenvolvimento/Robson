﻿using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using Robson.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Robson.Testes.Data.FormacaoRepositoryTeste
{
    public class FormacaoRepositoryTodos
    {
        [Fact]
        public async Task RetornaListaDeTodoAsFormacoes()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var repository = new FormacaoRepository(new(options));

            var listaDeFormacoes = new List<Formacao>
            {
                new()
                {
                    Nome = "Curso de Desenvolvimento C#",
                    Descricao = "Curso de Desenvolvimento C#",
                    InstituicaoId = 1,
                    DataInicio = DateTime.Parse("2020-12-12"),
                    DataConclusao = DateTime.Parse("2020-12-12")
                },
                new()
                {
                    Nome = "Curso de Desenvolvimento Asp.Net Core",
                    Descricao = "Curso de Desenvolvimento Asp.Net Core",
                    InstituicaoId = 1,
                    DataInicio = DateTime.Parse("2020-12-12"),
                    DataConclusao = DateTime.Parse("2020-11-12")
                },
                new()
                {
                    Nome = "Curso de Desenvolvimento C++",
                    Descricao = "Curso de Desenvolvimento C++",
                    InstituicaoId = 1,
                    DataInicio = DateTime.Parse("2020-12-12"),
                    DataConclusao = DateTime.Parse("2020-11-12")
                }
            };

            await repository.IncluirListaAsync(listaDeFormacoes);

            var totalDeRegistrosInseridos = await repository.Todos();

            Assert.Equal(3, totalDeRegistrosInseridos.ToList().Count);
        }
    }
}