using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using Robson.Domain.Entities;
using System;
using System.Collections.Generic;
using Xunit;

namespace Robson.Testes.Data.InstituicaoRepositoryTeste
{
    public class InstituicaoRepositoryPesquisarAsync
    {
        [Fact]
        public async void PesquisaPorNomeERetornaInstituicao()
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

            var pesquisaInstituicao = await repository.PesquisarAsync(curso => curso.Nome == "Alura");
            Assert.True(pesquisaInstituicao.Id == 1 && pesquisaInstituicao.Nome == "Alura");
        }
    }
}
