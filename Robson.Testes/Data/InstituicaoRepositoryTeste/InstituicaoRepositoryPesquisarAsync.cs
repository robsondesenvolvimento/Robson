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
    public class InstituicaoRepositoryPesquisarAsync
    {
        [Fact]
        public async void PesquisaPorNomeERetornaInstituicao()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var repository = new InstituicaoRepository(new(options));

            var instituicoes = new InstituicaoBuilder()
                .BuildListState();

            await repository.IncluirListaAsync(instituicoes);

            var pesquisaInstituicao = await repository.PesquisarAsync(curso => curso.Nome == "Alura");
            Assert.True(pesquisaInstituicao.Id == 1 && pesquisaInstituicao.Nome == "Alura");
        }
    }
}
