using Robson.Services.Common.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Robson.WebApplication.Services
{
    public class CarreiraService : ICarreiraService
    {
        private readonly HttpClient _httpClient;

        public CarreiraService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CarreiraViewModel> GetCarreira(int id)
        {
            var response = await _httpClient.GetAsync($"carreira/{id}");

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    IgnoreNullValues = true,
                    WriteIndented = false
                };

                var carreira = await JsonSerializer.DeserializeAsync<CarreiraViewModel>(responseStream, options);
                return carreira;
            }

            return null;
        }

        public async Task<IEnumerable<CarreiraViewModel>> GetCarreiras()
        {
            var response = await _httpClient.GetAsync("carreira");

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    IgnoreNullValues = true,
                    WriteIndented = false
                };

                var carreiras = await JsonSerializer.DeserializeAsync<IEnumerable<CarreiraViewModel>>(responseStream, options);
                return carreiras;
            }

            return null;
        }
    }
}
