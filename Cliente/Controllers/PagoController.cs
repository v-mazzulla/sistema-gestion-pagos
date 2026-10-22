using HTTPClienteObligatorio.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using Obligatorio.WebApp.Filtros;
using System.Net.Http.Headers;

namespace HTTPClienteObligatorio.Controllers
{
    public class PagoController : Controller
    {
        private HttpClient _httpClient;

        public PagoController(HttpClient client, IConfiguration configuration)
        {
            _httpClient = client;
            _httpClient.BaseAddress = new Uri(configuration["ApiBaseUrl"] ?? throw new InvalidOperationException("Falta ApiBaseUrl en la configuración."));
        }


        [Logueado]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            string token = HttpContext.Session.GetString("Token");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var responseTP = await _httpClient.GetAsync("TipoGasto");
            var responseMP = await _httpClient.GetAsync("MetodoPago");

            if (responseTP.IsSuccessStatusCode && responseMP.IsSuccessStatusCode)
            {
                var resultTP = await responseTP.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                var resultMP = await responseMP.Content.ReadAsStringAsync();

                AltaPagoVM vm = new AltaPagoVM();
                vm.TiposDeGasto = JsonSerializer.Deserialize<List<DTOTipoGasto>>(resultTP, options);
                vm.MetodosPago = JsonSerializer.Deserialize<List<DTOMetodoPago>>(resultMP, options);

                return View(vm);
            }
            else
            {

                ViewBag.msg = "Datos incorrectos";
                return View();

            }
        }

        [Logueado]
        [HttpPost]
        public async Task<IActionResult> Create(AltaPagoVM vm)
        {

            var body = JsonSerializer.Serialize(vm.Dto);

            var content = new StringContent(body, Encoding.UTF8, "application/json");

            string token = HttpContext.Session.GetString("Token");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.PostAsync("Pago", content);

            if (response.IsSuccessStatusCode) {
                ViewBag.msgS = "Alta Correcta";
            }
            else if ((int)response.StatusCode == 400)
            {
                var result = await response.Content.ReadAsStringAsync();
                ViewBag.Mensaje = result;
            }
            else
            {
                ViewBag.Mensaje = "Ha ocurrido un error, intente de nuevo mas tarde";
            }

            var responseTP = await _httpClient.GetAsync("TipoGasto");
            var responseMP = await _httpClient.GetAsync("MetodoPago");

            if (responseTP.IsSuccessStatusCode && responseMP.IsSuccessStatusCode)
            {
                var resultTP = await responseTP.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                var resultMP = await responseMP.Content.ReadAsStringAsync();

                vm.TiposDeGasto = JsonSerializer.Deserialize<List<DTOTipoGasto>>(resultTP, options);
                vm.MetodosPago = JsonSerializer.Deserialize<List<DTOMetodoPago>>(resultMP, options);

                return View(vm);
            }

            return View(vm);
        }

        [LogueadoEmpleadoOGerente]
        [HttpGet]
        public async Task<IActionResult> List()
        {

            string token = HttpContext.Session.GetString("Token");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync("Usuario");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var listaPagos = JsonSerializer.Deserialize<List<DTOPago>>(result, options);

                if (listaPagos.Count() == 0)
                {
                    ViewBag.Mensaje = "No cuenta con ningun pago";
                }

                return View(listaPagos);
            }
            else
            {
                ViewBag.Mensaje = "Ha ocurrido un error, intente de nuevo mas tarde";
                return View();
            }
        }
    }
}
