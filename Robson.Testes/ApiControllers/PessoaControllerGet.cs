using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Robson.Api.Controllers;
using Robson.Api.Mappings;
using Robson.Data.Context;
using Robson.Data.Repositories;
using Robson.Testes.DataBuilder;
using System;
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

            var listaDePessoas = new PessoaBuilder()
                .BuildListState();

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
