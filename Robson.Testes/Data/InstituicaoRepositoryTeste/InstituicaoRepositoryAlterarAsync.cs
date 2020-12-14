using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using Robson.Domain.Entities;
using System;
using System.Collections.Generic;
using Xunit;

namespace Robson.Testes.Data.InstituicaoRepositoryTeste
{
    public class InstituicaoRepositoryAlterarAsync
    {
        [Fact]
        public async void AlteraDadosDaInstituicao()
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

            var pesquisaInstituicoes = await repository.PesquisarIdAsync(2);

            pesquisaInstituicoes.Nome = "Udemy X";

            await repository.AlterarAsync(pesquisaInstituicoes);

            pesquisaInstituicoes = await repository.PesquisarIdAsync(2);

            Assert.Equal("Udemy X", pesquisaInstituicoes.Nome);
        }
    }
}
