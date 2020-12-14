using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Robson.Testes.Data.FormacaoRepositoryTeste
{
    public class FormacaoRepositoryIncluirAsync
    {
        [Fact]
        public async Task IncluirFormacaoERetornaNovoIdDaFormacaoIncluida()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var repository = new FormacaoRepository(new(options));

            var formacaoId = await repository.IncluirAsync(
                new()
                {
                    Nome = "Curso de Desenvolvimento C#",
                    Descricao = "Curso de Desenvolvimento C#",
                    InstituicaoId = 1,
                    DataInicio = DateTime.Parse("2020-12-12"),
                    DataConclusao = DateTime.Parse("2020-12-12")
                }
            );

            Assert.Equal(1, formacaoId);
        }
    }
}
