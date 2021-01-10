using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using Robson.Testes.DataBuilder;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Robson.Testes.Data.FormacaoRepositoryTeste
{
    public class FormacaoRepositoryPesquisarIdAsync
    {
        [Fact]
        public async Task PesquisarPorIdERetornaFormacao()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var repository = new FormacaoRepository(new(options));

            var listaDeFormacoes = new FormacaoBuilder()
                .BuildListState();

            await repository.IncluirListaAsync(listaDeFormacoes);

            var buscaFormacao = await repository.PesquisarIdAsync(2);
            Assert.Equal("Curso de Desenvolvimento Asp.Net Core", buscaFormacao.Nome);
        }
    }
}
