using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Robson.Api;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;

namespace Robson.Testes.HttpBuilder
{
    public class HttpClientBuilder
    {
        public HttpClient BuildHttpClient()
        {
            var _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            var _client = _server.CreateClient();
            _client.BaseAddress = new Uri("http://localhost/api/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json));

            return _client;
        }
    }
}
