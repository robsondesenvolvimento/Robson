using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using Robson.Testes.DataBuilder;
using System;
using Xunit;

namespace Robson.Testes.Data.InstituicaoRepositoryTeste
{
    public class InstituicaoRepositoryExcluirAsync
    {
        [Fact]
        public async void ExcluirInstituicao()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var repository = new InstituicaoRepository(new(options));

            var instituicoes = new InstituicaoBuilder()
                .BuildListState();

            await repository.IncluirListaAsync(instituicoes);

            await repository.ExcluirAsync(1);

            var pesquisaInstituicao = await repository.PesquisarIdAsync(1);

            Assert.Null(pesquisaInstituicao);
        }
    }
}
