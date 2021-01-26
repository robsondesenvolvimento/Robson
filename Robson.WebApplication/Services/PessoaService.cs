using Robson.Services.Common.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Robson.WebApplication.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly HttpClient _httpClient;

        public PessoaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PessoaViewModel> GetPessoa(int id)
        {
            var response = await _httpClient.GetAsync($"pessoa/{id}");

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    IgnoreNullValues = true,
                    WriteIndented = false
                };

                var pessoa = await JsonSerializer.DeserializeAsync<PessoaViewModel>(responseStream, options);
                return pessoa;
            }

            return null;
        }

        public async Task<IEnumerable<PessoaViewModel>> GetPessoas()
        {
            var response = await _httpClient.GetAsync("pessoa");

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    IgnoreNullValues = true,
                    WriteIndented = false
                };

                var pessoas = await JsonSerializer.DeserializeAsync<IEnumerable<PessoaViewModel>>(responseStream, options);
                return pessoas;
            }

            return null;
        }
    }
}
