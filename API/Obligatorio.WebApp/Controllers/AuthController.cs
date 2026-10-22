using Microsoft.AspNetCore.Mvc;
using Obligatorio.DTOs.DTOsUsuario;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.LogicaNegocio.CustomExceptions.CECompartidas;
using Obligatorio.WebApp.Filtros;

namespace Obligatorio.WebApp.Controllers
{
    public class AuthController : Controller
    {
        private ICULogin _CULogin;
        public AuthController(ICULogin CULogin)
        {
            _CULogin = CULogin;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(DTOLogin dto)
        {
            try
            {
                DTOUsuario u = _CULogin.VerificarExistencia(dto);

                HttpContext.Session.SetString("EmailLogueado", u.Email);
                HttpContext.Session.SetString("RolLogueado", u.Rol);

                return RedirectToAction("Index", "Home");
            }
            catch (DatosInvalidosException e)
            {
                ViewBag.Mensaje = "Los datos no son válidos";
            }
            catch (Exception e)
            {
                ViewBag.Mensaje = "Ha ocurrido un error, intente de nuevo mas tarde"; ;
            }
            return View();
        }

        [Logueado]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Auth");
        }
    }
}
