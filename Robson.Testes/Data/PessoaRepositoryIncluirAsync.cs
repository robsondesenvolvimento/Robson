using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Robson.Domain.Entities;

namespace Robson.Testes.Data
{
    public class PessoaRepositoryIncluirAsync
    {
        [Fact]
        public async Task IncluirPessoaEVerificaIdRetornado()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase("PessoaRepositoryIncluirAsync")
                .Options;

            var repository = new PessoaRepository(new(options));

            var pessoaId = await repository.IncluirAsync(
                new()
                {
                    Nome = "Teste de Unidade Pessoa",
                    Nascimento = DateTime.Parse("2019-07-21"),
                    Celular = "(41) 98827-07693",
                    Cep = "80050-205",
                    Rua = "Rua Do Herval, 378",
                    Complemento = "Apto. 3",
                    Bairro = "Cristo Rei",
                    Cidade = "Curitiba",
                    Estado = "Paraná",
                    Pais = "Brasil"
                }
            );

            Assert.Equal(1, pessoaId);
        }
    }
}
