using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using Robson.Testes.DataBuilder;
using System;
using Xunit;

namespace Robson.Testes.Data.FormacaoRepositoryTeste
{
    public class FormacaoRepositoryPesquisarAsync
    {
        [Fact]
        public async void PesquisaPorNomeERetornaFormacao()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var repository = new FormacaoRepository(new(options));

            var listaDeFormacoes = new FormacaoBuilder()
                .BuildListState();

            await repository.IncluirListaAsync(listaDeFormacoes);

            var pesquisaFormacao = await repository.PesquisarAsync(curso => curso.Nome == "Curso de Desenvolvimento Asp.Net Core");
            Assert.Equal(2, pesquisaFormacao.Id);
        }
    }
}
