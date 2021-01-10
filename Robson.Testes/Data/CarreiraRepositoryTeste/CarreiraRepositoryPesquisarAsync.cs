using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using Robson.Testes.DataBuilder;
using System;
using Xunit;

namespace Robson.Testes.Data.CarreiraRepositoryTeste
{
    public class CursoRepositoryPesquisarAsync
    {
        [Fact]
        public async void PesquisaPorNomeERetornaCarreira()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var repository = new CarreiraRepository(new(options));

            var listaDeCarreiras = new CarreiraBuilder()
                .BuildListState();

            await repository.IncluirListaAsync(listaDeCarreiras);

            var pesquisaCarreira = await repository.PesquisarAsync(carreira => carreira.Empresa == "Escriba");
            Assert.Equal(2, pesquisaCarreira.Id);
        }
    }
}
