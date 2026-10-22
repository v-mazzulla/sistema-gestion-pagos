using HTTPClienteObligatorio.Models;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.WebApp.Filtros;
using System.Net.Http.Headers;
using System.Text.Json;

namespace HTTPClienteObligatorio.Controllers
{
    public class EquipoController : Controller
    {
        private HttpClient _httpClient;

        public EquipoController(HttpClient client, IConfiguration configuration)
        {
            _httpClient = client;
            _httpClient.BaseAddress = new Uri(configuration["ApiBaseUrl"] ?? throw new InvalidOperationException("Falta ApiBaseUrl en la configuración."));
        }

        [LogueadoGerente]
        [HttpGet]
        public IActionResult BuscarEquiposPorMonto()
        {
            return View(new List<DTOEquipo>());
        }

        [LogueadoGerente]
        [HttpPost]
        public async Task<IActionResult> BuscarEquiposPorMonto(int monto)
        {
            string token = HttpContext.Session.GetString("Token");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync($"Equipo?monto={monto}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                List<DTOEquipo> equipos = JsonSerializer.Deserialize<List<DTOEquipo>>(result, options);

                return View(equipos);
            }
            else
            {
                var errorBody = await response.Content.ReadAsStringAsync();
                ViewBag.Mensaje = $"Error {response.StatusCode}: {errorBody}";
                return View(new List<DTOEquipo>());
            }
        }
    }
}
