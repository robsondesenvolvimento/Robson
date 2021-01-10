using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using Robson.Testes.DataBuilder;
using System;
using Xunit;

namespace Robson.Testes.Data.PessoaRepositoryTeste
{
    public class PessoaRepositoryAlterarAsync
    {
        [Fact]
        public async void AlteraDadosDaPessoa()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var repository = new PessoaRepository(new(options));

            var pessoasBuilder = new PessoaBuilder()
                .BuildListState();

            await repository.IncluirListaAsync(pessoasBuilder);

            var pesquisaPessoa = await repository.PesquisarIdAsync(2);

            pesquisaPessoa.Nome = "Fulano foi alterado";

            await repository.AlterarAsync(pesquisaPessoa);

            pesquisaPessoa = await repository.PesquisarIdAsync(2);

            Assert.Equal("Fulano foi alterado", pesquisaPessoa.Nome);
        }
    }
}
