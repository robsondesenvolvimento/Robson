﻿using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using Robson.Testes.DataBuilder;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Robson.Testes.Data.CarreiraRepositoryTeste
{
    public class CursoRepositoryIncluirAsync
    {
        [Fact]
        public async Task IncluirCarreiraERetornaNovoIdDaCarreiraIncluida()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var repository = new CarreiraRepository(new(options));

            var carreira = new CarreiraBuilder()
                .BuildSingleState();

            var carreiraId = await repository.IncluirAsync(carreira);

            Assert.Equal(1, carreiraId);
        }
    }
}
