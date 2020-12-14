using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using Robson.Domain.Entities;
using System;
using System.Collections.Generic;
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

            await repository.IncluirListaAsync(listaDeInstituicoes);

            await repository.ExcluirAsync(1);

            var pesquisaInstituicao = await repository.PesquisarIdAsync(1);

            Assert.Null(pesquisaInstituicao);
        }
    }
}
