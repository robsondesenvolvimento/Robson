using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using Robson.Testes.DataBuilder;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Robson.Testes.Data.PessoaRepositoryTeste
{
    public class PessoaRepositoryPesquisarIdAsync
    {
        [Fact]
        public async Task PesquisarPorIdERetornaPessoa()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var repository = new PessoaRepository(new(options));

            var pessoasBuilder = new PessoaBuilder()
                .BuildListState();

            await repository.IncluirListaAsync(pessoasBuilder);

            var buscaPessoa = await repository.PesquisarIdAsync(2);
            Assert.Equal("Henrique Casagrande dos Santos Alves", buscaPessoa.Nome);
        }
    }
}
