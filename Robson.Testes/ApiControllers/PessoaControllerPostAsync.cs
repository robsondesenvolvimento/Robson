using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Robson.Api;
using Robson.Services.Common.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Robson.Testes.ApiControllers
{
    public class PessoaControllerPostAsync
    {
        private readonly HttpClient _client;

        public PessoaControllerPostAsync()
        {
            var _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
            _client.BaseAddress = new Uri("http://localhost/api/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json));
        }

        [Fact]
        public async Task PessoaControllerInsereNovaPessoa()
        {
            //var response = await _client.GetAsync("pessoa");
            //response.EnsureSuccessStatusCode();

            //response.StatusCode.Should().Be(HttpStatusCode.OK, $"* Ocorreu uma falha: Status Code esperado ({(int)HttpStatusCode.OK}, {HttpStatusCode.OK.ToString()}) diferente do resultado gerado *");

            //var responseOpbject = await response.Content.ReadFromJsonAsync<List<PessoaViewModel>>();

            //responseOpbject.Should().BeOfType<List<PessoaViewModel>>("O objeto esperado não é um ViewModel");

            var pessoaViewModel = new PessoaViewModel
            {
                Id = 0,
                Nome = "Ana Julia Casagrande da Silva",
                Nascimento = DateTime.Parse("1972-08-29"),
                Celular = "(41) 0000-00",
                Email = "ana@gmail.com",
                Cep = "80050-205",
                Rua = "Rua do Herval, 0000",
                Complemento = "Apto. 1",
                Bairro = "Cristo Rei",
                Cidade = "Curitiba",
                Estado = "Parana",
                Pais = "Brasil"
            };

            var serializado = JsonSerializer.Serialize(pessoaViewModel);

            var contents = new StringContent(
                serializado,
                Encoding.UTF8,
                MediaTypeNames.Application.Json);

            var post = await _client.PostAsync("pessoa", contents);

            post.StatusCode.Should().Be(HttpStatusCode.Created, $"* Ocorreu uma falha: Status Code esperado ({(int)HttpStatusCode.Created}, {HttpStatusCode.Created.ToString()}) diferente do resultado gerado *");
        }
    }
}
