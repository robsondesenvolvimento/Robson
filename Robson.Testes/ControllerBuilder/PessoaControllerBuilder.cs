using AutoMapper;
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

namespace Robson.Testes.ControllerBuilder
{
    public class PessoaControllerBuilder : IBuilderController<PessoaController>
    {
        public async Task<PessoaController> BuildController()
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

            return new PessoaController(mockLogger.Object, mapper, repository);
        }
    }
}
