using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Robson.Api.Controllers;
using Robson.Api.Mappings;
using Robson.Data.Context;
using Robson.Data.Repositories;
using Robson.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Robson.Testes.ApiControllers
{
    public class PessoaControllerGet
    {
        [Fact]
        public async Task FazRequisicaoRecursoPessoaMetodoGetERecebeUmaListaDePessoasAsync()
        {
            var mockLogger = new Mock<ILogger<PessoaController>>();

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var repository = new PessoaRepository(new(options));

            var listaDePessoas = new List<Pessoa>
            {
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
                },
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
                },
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
            };

            await repository.IncluirListaAsync(listaDePessoas);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToViewModelMappingProfile());
                cfg.AddProfile(new ViewModelToDomainMappingProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var pessoaController = new PessoaController(mockLogger.Object, mapper, repository);

            var content = pessoaController.Get().Result;
            Assert.IsType<OkObjectResult>(content.Result);
        }
    }
}
