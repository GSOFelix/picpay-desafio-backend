using Aplicacao.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infra.Services
{
    public class AuthorizeService : IAuthorizeService
    {
        private readonly HttpClient _httpClient;

        public AuthorizeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<bool> VerifyAuthorization()
        {
            var response = await _httpClient.GetAsync("https://util.devi.tools/api/v2/authorize");

            var json = JsonDocument.Parse(await response.Content.ReadAsStreamAsync());

            return json.RootElement
                .GetProperty("data")
                .GetProperty("authorization")
                .GetBoolean();
        }
    }
}
