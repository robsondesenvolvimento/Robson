using Robson.Services.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
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
        public async Task<IEnumerable<PessoaViewModel>> GetPessoas()
        {
            var response = await _httpClient.GetAsync("pessoa");
            var responseStream = await response.Content.ReadAsStreamAsync();

            if (response.IsSuccessStatusCode)
            {
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
