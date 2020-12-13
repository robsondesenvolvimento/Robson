using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Robson.Testes.Data.CarreiraRepositoryTeste
{
    public class CursoRepositoryIncluirAsync
    {
        [Fact]
        public async Task IncluirCarreiraERetornaNovoIdDaCarreiraIncluida()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var repository = new CarreiraRepository(new(options));

            var carreiraId = await repository.IncluirAsync(
                new()
                {
                    Empresa = "Teste de Unidade Carreira 1",
                    Funcao = "Teste de Unidade Carreira 1",
                    Descricao = "Teste de Unidade Carreira 1",
                    DataInicio = DateTime.Parse("2000-02-02"),
                    DataSaida = DateTime.Parse("2005-04-01")
                }
            );

            Assert.Equal(1, carreiraId);
        }
    }
}
