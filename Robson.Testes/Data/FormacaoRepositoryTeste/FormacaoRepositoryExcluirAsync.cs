using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using Robson.Domain.Entities;
using Robson.Testes.DataBuilder;
using System;
using System.Collections.Generic;
using Xunit;

namespace Robson.Testes.Data.FormacaoRepositoryTeste
{
    public class FormacaoRepositoryExcluirAsync
    {
        [Fact]
        public async void ExcluirFormacao()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var repository = new FormacaoRepository(new(options));

            var listaDeFormacoes = new FormacaoBuilder()
                .BuildListState();

            await repository.IncluirListaAsync(listaDeFormacoes);

            await repository.ExcluirAsync(1);

            var pesquisaFormacao = await repository.PesquisarIdAsync(1);

            Assert.Null(pesquisaFormacao);
        }
    }
}
