using FluentAssertions;
using Robson.Services.Common.Models;
using Robson.Testes.HttpBuilder;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
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
            _client = new HttpClientBuilder().BuildHttpClient();
        }

        [Fact]
        public async Task FazUmaRequisicaoPostERetornaStatusCodeCreated()
        {
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

            var responseOpbject = await post.Content.ReadFromJsonAsync<PessoaViewModel>();

            responseOpbject.Should().BeOfType<PessoaViewModel>("O objeto esperado não é um ViewModelPessoa");
        }
    }
}
