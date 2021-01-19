using Microsoft.AspNetCore.Mvc;
using Robson.Services.Common.Models;
using Robson.Testes.ControllerBuilder;
using System.Threading.Tasks;
using Xunit;

namespace Robson.Testes.ApiControllers
{
    public class PessoaControllerGetIdAsync
    {
        [Fact]
        public async Task FazRequisicaoRecursoPessoaMetodoGetIdAsyncERecebeUmaDePessoa()
        {
            var pessoaController = await new PessoaControllerBuilder()
                .BuildController();

            var content = await pessoaController.GetIdAsync(2);
            var okObjectResult = Assert.IsType<OkObjectResult>(content.Result).Value as PessoaViewModel;
            Assert.IsType<PessoaViewModel>(okObjectResult);
            Assert.Equal("Henrique Casagrande dos Santos Alves", okObjectResult.Nome);
        }
    }
}
