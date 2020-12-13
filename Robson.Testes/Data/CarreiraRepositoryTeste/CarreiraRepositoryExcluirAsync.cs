﻿using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using Robson.Domain.Entities;
using System;
using System.Collections.Generic;
using Xunit;

namespace Robson.Testes.Data.CarreiraRepositoryTeste
{
    public class CursoRepositoryExcluirAsync
    {
        [Fact]
        public async void ExcluirCarreira()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var repository = new CarreiraRepository(new(options));

            var listaDeCarreiras = new List<Carreira>
            {
                new()
                {
                    Empresa = "Teste de Unidade Carreira 1",
                    Funcao = "Teste de Unidade Carreira 1",
                    Descricao = "Teste de Unidade Carreira 1",
                    DataInicio = DateTime.Parse("2000-02-02"),
                    DataSaida = DateTime.Parse("2005-04-01")
                },
                new()
                {
                    Empresa = "Teste de Unidade Carreira 2",
                    Funcao = "Teste de Unidade Carreira 2",
                    Descricao = "Teste de Unidade Carreira 2",
                    DataInicio = DateTime.Parse("2000-02-02"),
                    DataSaida = DateTime.Parse("2005-04-01")
                },
                new()
                {
                    Empresa = "Teste de Unidade Carreira 3",
                    Funcao = "Teste de Unidade Carreira 3",
                    Descricao = "Teste de Unidade Carreira 3",
                    DataInicio = DateTime.Parse("2000-02-02"),
                    DataSaida = DateTime.Parse("2005-04-01")
                }
            };

            await repository.IncluirListaAsync(listaDeCarreiras);

            await repository.ExcluirAsync(1);

            var pesquisaCarreira = await repository.PesquisarIdAsync(1);

            Assert.Null(pesquisaCarreira);
        }
    }
}