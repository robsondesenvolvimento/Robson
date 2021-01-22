using FluentAssertions;
using Robson.Services.Common.Models;
using Robson.Testes.HttpBuilder;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace Robson.Testes.ApiControllers
{
    public class PessoaControllerGetIdAsync
    {
        private readonly HttpClient _client;

        public PessoaControllerGetIdAsync()
        {
            _client = new HttpClientBuilder().BuildHttpClient();
        }

        [Fact]
        public async Task FazUmaRequisicaoGetERetornaStatusCodeOKePessoaNoCorpo()
        {
            var response = await _client.GetAsync("pessoa/1");
            response.EnsureSuccessStatusCode();

            response.StatusCode.Should().Be(HttpStatusCode.OK, $"* Ocorreu uma falha: Status Code esperado ({(int)HttpStatusCode.OK}, {HttpStatusCode.OK.ToString()}) diferente do resultado gerado *");

            var responseOpbject = await response.Content.ReadFromJsonAsync<PessoaViewModel>();

            responseOpbject.Should().BeOfType<PessoaViewModel>("O objeto esperado não é um ViewModelPessoa");
        }
    }
}
