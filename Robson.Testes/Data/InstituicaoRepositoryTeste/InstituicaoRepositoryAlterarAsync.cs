using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using Robson.Domain.Entities;
using Robson.Testes.DataBuilder;
using System;
using System.Collections.Generic;
using Xunit;

namespace Robson.Testes.Data.InstituicaoRepositoryTeste
{
    public class InstituicaoRepositoryAlterarAsync
    {
        [Fact]
        public async void AlteraDadosDaInstituicao()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var repository = new InstituicaoRepository(new(options));

            var instituicoes = new InstituicaoBuilder()
                .BuildListState();

            await repository.IncluirListaAsync(instituicoes);

            var pesquisaInstituicoes = await repository.PesquisarIdAsync(2);

            pesquisaInstituicoes.Nome = "Udemy X";

            await repository.AlterarAsync(pesquisaInstituicoes);

            pesquisaInstituicoes = await repository.PesquisarIdAsync(2);

            Assert.Equal("Udemy X", pesquisaInstituicoes.Nome);
        }
    }
}
