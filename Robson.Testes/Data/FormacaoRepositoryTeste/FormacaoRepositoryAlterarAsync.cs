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
    public class FormacaoRepositoryAlterarAsync
    {
        [Fact]
        public async void AlteraDadosDaFormacao()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var repository = new FormacaoRepository(new(options));

            var listaDeFormacoes = new FormacaoBuilder()
                .BuildListState();

            await repository.IncluirListaAsync(listaDeFormacoes);

            var pesquisaFormacoes = await repository.PesquisarIdAsync(2);

            pesquisaFormacoes.Nome = "Curso de Desenvolvimento Asp.Net Core X";

            await repository.AlterarAsync(pesquisaFormacoes);

            pesquisaFormacoes = await repository.PesquisarIdAsync(2);

            Assert.Equal("Curso de Desenvolvimento Asp.Net Core X", pesquisaFormacoes.Nome);
        }
    }
}
