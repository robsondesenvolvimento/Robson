using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using Robson.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Robson.Testes.Data.InstituicaoRepositoryTeste
{
    public class InstituicaoRepositoryIncluirListaAsync
    {
        [Fact]
        public async Task IncluirListaDeInstituicoesERetornaTotalDeRegistrosInseridos()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var repository = new InstituicaoRepository(new(options));

            var listaDeInstituicoes = new List<Instituicao>
            {
                new()
                {
                    Nome = "Alura"
                },
                new()
                {
                    Nome = "Udemy"
                }
            };

            var totalDeRegistrosInseridos = await repository.IncluirListaAsync(listaDeInstituicoes);

            Assert.Equal(2, totalDeRegistrosInseridos);
        }
    }
}
