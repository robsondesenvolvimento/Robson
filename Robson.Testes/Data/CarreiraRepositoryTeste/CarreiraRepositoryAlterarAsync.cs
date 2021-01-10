using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using Robson.Domain.Entities;
using Robson.Testes.DataBuilder;
using System;
using System.Collections.Generic;
using Xunit;

namespace Robson.Testes.Data.CarreiraRepositoryTeste
{
    public class CursoRepositoryAlterarAsync
    {
        [Fact]
        public async void AlteraDadosDaCarreira()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var repository = new CarreiraRepository(new(options));

            var listaDeCarreiras = new CarreiraBuilder()
                .BuildListState();

            var totalDeRegistrosInseridos = await repository.IncluirListaAsync(listaDeCarreiras);

            var pesquisaCarreira = await repository.PesquisarIdAsync(2);

            pesquisaCarreira.Empresa = "Teste de Unidade Carreira 2 X";

            await repository.AlterarAsync(pesquisaCarreira);

            pesquisaCarreira = await repository.PesquisarIdAsync(2);

            Assert.Equal("Teste de Unidade Carreira 2 X", pesquisaCarreira.Empresa);
        }
    }
}
