using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using Robson.Testes.DataBuilder;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Robson.Testes.Data.CarreiraRepositoryTeste
{
    public class CursoRepositoryPesquisarIdAsync
    {
        [Fact]
        public async Task PesquisarPorIdERetornaCarreira()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var repository = new CarreiraRepository(new(options));

            var listaDeCarreiras = new CarreiraBuilder()
                .BuildListState();

            await repository.IncluirListaAsync(listaDeCarreiras);

            var buscaCarreira = await repository.PesquisarIdAsync(2);
            Assert.Equal("Escriba", buscaCarreira.Empresa);
        }
    }
}
