using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BladeRunner2077.Integration.galletafortuna
{
    public class GalletaFortunaApiIntegration
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<GalletaFortunaApiIntegration> _logger;
        private const string API_URL = "https://fortune-cookie4.p.rapidapi.com/slack";
        private const string API_KEY = "2191cd0a2emshaadf9a8a81936fdp12ad70jsn4d182af0524c";  // Asegúrate de mantener esta clave segura

        public GalletaFortunaApiIntegration(HttpClient httpClient, ILogger<GalletaFortunaApiIntegration> logger)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<string> ObtenerGalletaDeLaFortunaAsync()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_URL),
            };
            request.Headers.Add("x-rapidapi-key", API_KEY);
            request.Headers.Add("x-rapidapi-host", "fortune-cookie4.p.rapidapi.com");

            try
            {
                using (var response = await _httpClient.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    return body;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching fortune cookie message.");
                throw;
            }
        }
    }
}