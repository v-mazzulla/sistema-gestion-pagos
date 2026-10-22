using HTTPClienteObligatorio.Models;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.WebApp.Filtros;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using System.Text;

namespace HTTPClienteObligatorio.Controllers
{
    public class UsuarioController : Controller
    {
        private HttpClient _httpClient;
        public UsuarioController(HttpClient client, IConfiguration configuration)
        {
            _httpClient = client;
            _httpClient.BaseAddress = new Uri(configuration["ApiBaseUrl"] ?? throw new InvalidOperationException("Falta ApiBaseUrl en la configuración."));
        }

        [LogueadoAdmin]
        [HttpGet]
        public IActionResult CambioContrasena()
        {
            return View();
        }

        [LogueadoAdmin]
        [HttpPost]
        public async Task<IActionResult> CambioContrasena(string usuarioEmail)
        {
            string token = HttpContext.Session.GetString("Token");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var emptyContent = new StringContent("", Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"Usuario?emailUsuario={usuarioEmail}", emptyContent);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                ViewBag.Mensaje = $"La nueva contraseña del usuario es: {result}," +
                    $" por favor anotela en un lugar seguro y notifique al usario.";
                return View();
            }
            else if ((int)response.StatusCode == 404)
            {
                var result = await response.Content.ReadAsStringAsync();
                ViewBag.MensajeE = result;
                return View();
            }
            else
            {
                ViewBag.MensajeE = "Ha ocurrido un error, intente de nuevo mas tarde";
                return View();
            }
        }
    }
}
