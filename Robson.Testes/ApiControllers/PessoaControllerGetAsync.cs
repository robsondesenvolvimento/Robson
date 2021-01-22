using FluentAssertions;
using Robson.Services.Common.Models;
using Robson.Testes.HttpBuilder;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace Robson.Testes.ApiControllers
{
    public class PessoaControllerGetAsync
    {
        private readonly HttpClient _client;

        public PessoaControllerGetAsync()
        {
            _client = new HttpClientBuilder().BuildHttpClient();
        }

        [Fact]
        public async Task FazUmaRequisicaoGetERetornaStatusCodeOKeListaDePessoasNoCorpo()
        {
            var response = await _client.GetAsync("pessoa");
            response.EnsureSuccessStatusCode();

            response.StatusCode.Should().Be(HttpStatusCode.OK, $"* Ocorreu uma falha: Status Code esperado ({(int)HttpStatusCode.OK}, {HttpStatusCode.OK.ToString()}) diferente do resultado gerado *");

            var responseOpbject = await response.Content.ReadFromJsonAsync<List<PessoaViewModel>>();

            responseOpbject.Should().BeOfType<List<PessoaViewModel>>("O objeto esperado não é um ViewModelPessoa");
        }
    }
}
