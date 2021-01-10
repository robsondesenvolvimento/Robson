using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using Robson.Testes.DataBuilder;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Robson.Testes.Data.InstituicaoRepositoryTeste
{
    public class InstituicaoRepositoryPesquisarIdAsync
    {
        [Fact]
        public async Task PesquisarPorIdERetornaInstituicao()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var repository = new InstituicaoRepository(new(options));

            var instituicoes = new InstituicaoBuilder()
                .BuildListState();

            await repository.IncluirListaAsync(instituicoes);

            var buscaInstituicao = await repository.PesquisarIdAsync(2);
            Assert.Equal("Udemy", buscaInstituicao.Nome);
        }
    }
}
