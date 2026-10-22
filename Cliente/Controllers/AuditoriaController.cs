using HTTPClienteObligatorio.Models;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.WebApp.Filtros;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace HTTPClienteObligatorio.Controllers
{
    public class AuditoriaController : Controller
    {
        private HttpClient _httpClient;

        public AuditoriaController(HttpClient client, IConfiguration configuration)
        {
            _httpClient = client;
            _httpClient.BaseAddress = new Uri(configuration["ApiBaseUrl"] ?? throw new InvalidOperationException("Falta ApiBaseUrl en la configuración."));
        }

        [LogueadoAdmin]
        [HttpGet]
        public IActionResult List()
        {
            return View();
        }

        [LogueadoAdmin]
        [HttpPost]
        public async Task<IActionResult> List(int idBuscar)
        {
            string token = HttpContext.Session.GetString("Token");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync($"Auditoria?idTipoGasto={idBuscar}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var listAuditoria = JsonSerializer.Deserialize<List<DTOAuditoria>>(result, options);
                return View(listAuditoria); 
            }
            else if ((int)response.StatusCode == 404)
            {
                var result = await response.Content.ReadAsStringAsync();
                ViewBag.Mensaje = result;
                return View();
            }
            else
            {
                ViewBag.Mensaje = "Ha ocurrido un error, intente de nuevo mas tarde";
                return View();
            }
        }
    }
}
