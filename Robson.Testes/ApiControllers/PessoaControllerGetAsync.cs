using Microsoft.AspNetCore.Mvc;
using Robson.Services.Common.Models;
using Robson.Testes.ControllerBuilder;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Robson.Testes.ApiControllers
{
    public class PessoaControllerGetAsync
    {
        [Fact]
        public async Task FazRequisicaoRecursoPessoaMetodoGetAsyncERecebeUmaListaDePessoas()
        {
            var pessoaController = await new PessoaControllerBuilder()
                .BuildController();

            var content = await pessoaController.GetAsync();
            var okObjectResult = Assert.IsType<OkObjectResult>(content.Result).Value as IEnumerable<PessoaViewModel>;
            Assert.IsType<PessoaViewModel>(okObjectResult.ToArray()[0]);
        }
    }
}
