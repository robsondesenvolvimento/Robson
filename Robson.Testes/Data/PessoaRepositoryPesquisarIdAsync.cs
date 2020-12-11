using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Robson.Data.Repositories;
using Robson.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;

namespace Robson.Testes.Data
{
    public class PessoaRepositoryPesquisarIdAsync
    {
        [Fact]
        public async Task PesquisarPorIdEConfirmarNomeDaPessoa()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase("PessoaRepositoryPesquisarIdAsync")
                .Options;

            var repository = new PessoaRepository(new(options));

            await repository.IncluirAsync(
                new()
                {
                    Nome = "Teste de Unidade Pessoa 1",
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

            await repository.IncluirAsync(
                new()
                {
                    Nome = "Teste de Unidade Pessoa 2",
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

            await repository.IncluirAsync(
                new()
                {
                    Nome = "Teste de Unidade Pessoa 3",
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

            var buscaPessoa = await repository.PesquisarIdAsync(2);
            Assert.Equal("Teste de Unidade Pessoa 2", buscaPessoa.Nome);
        }
    }
}
