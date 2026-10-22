using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using HTTPClienteObligatorio.Models;
using Microsoft.AspNetCore.Mvc;

namespace HTTPClienteObligatorio.Controllers
{
    public class AuthController : Controller
    {
        private HttpClient _httpClient;

        public AuthController(HttpClient client, IConfiguration configuration)
        {
            _httpClient = client;
            _httpClient.BaseAddress = new Uri(configuration["ApiBaseUrl"] ?? throw new InvalidOperationException("Falta ApiBaseUrl en la configuración."));
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(DTOLogin dto)
        {
            var body = JsonSerializer.Serialize(dto);

            var content = new StringContent(body, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("auth", content);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var loginResponse = JsonSerializer.Deserialize<LoginResponse>(result, options);

                HttpContext.Session.SetString("Token", loginResponse.Token);
                HttpContext.Session.SetString("RolLogueado", loginResponse.Rol);
                return RedirectToAction("Index", "Home");   
            }
            else if ((int)response.StatusCode == 409)
            {
                ViewBag.Mensaje = "Nombre y/o contraseña incorrectos";
                return View();
            }
            else
            {
                ViewBag.Mensaje = "Ha ocurrido un error, intente de nuevo mas tarde";
                return View();
            }
        }

        public IActionResult Logout() { 
        
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");

        }

    }
}
