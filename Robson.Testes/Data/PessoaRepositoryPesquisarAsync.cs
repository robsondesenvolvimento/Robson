﻿using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using System;
using Xunit;

namespace Robson.Testes.Data
{
    public class PessoaRepositoryPesquisarAsync
    {
        [Fact]
        public async void PesquisaPorNomeERetornaPessoa()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
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

            var pesquisaPessoa = await repository.PesquisarAsync(pessoa => pessoa.Nome == "Teste de Unidade Pessoa 3");
            Assert.Equal(3, pesquisaPessoa.Id);
        }
    }
}
