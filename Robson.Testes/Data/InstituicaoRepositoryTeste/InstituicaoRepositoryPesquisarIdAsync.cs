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
    public class InstituicaoRepositoryPesquisarIdAsync
    {
        [Fact]
        public async Task PesquisarPorIdERetornaInstituicao()
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

            var buscaInstituicao = await repository.PesquisarIdAsync(2);
            Assert.Equal("Udemy", buscaInstituicao.Nome);
        }
    }
}
