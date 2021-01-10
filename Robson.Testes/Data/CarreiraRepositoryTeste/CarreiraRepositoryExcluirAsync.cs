using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using Robson.Domain.Entities;
using Robson.Testes.DataBuilder;
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

            var listaDeCarreiras = new CarreiraBuilder()
                .BuildListState();

            await repository.IncluirListaAsync(listaDeCarreiras);

            await repository.ExcluirAsync(1);

            var pesquisaCarreira = await repository.PesquisarIdAsync(1);

            Assert.Null(pesquisaCarreira);
        }
    }
}
