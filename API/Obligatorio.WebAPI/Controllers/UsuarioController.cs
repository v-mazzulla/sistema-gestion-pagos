using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.DTOs.DTOsPago;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.LogicaNegocio.CustomExceptions.CECompartidas;
using System.Data;
using System.Security.Claims;

namespace Obligatorio.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {       
        private ICUPagosUsuario _CUPagosUsuario;
        private ICUResetearContrasenia _CUResetearContrasenia;
        public UsuarioController(ICUPagosUsuario CUPagosUsuario, ICUResetearContrasenia CUResetearContrasenia)
        {
            _CUPagosUsuario = CUPagosUsuario;
            _CUResetearContrasenia = CUResetearContrasenia;
        }


        [Authorize(Roles = "Empleado,Gerente")]
        [HttpGet]
        public IActionResult GetPagosDeUsuario()
        {
            try
            {
                string email = User.FindFirst(ClaimTypes.Email).Value;
                if (!string.IsNullOrWhiteSpace(email))
                {
                    List<DTOPago> pagos = _CUPagosUsuario.PagosDeUsuario(email);
                    return Ok(pagos);
                }
                else
                {
                    return BadRequest();
                }                
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }


        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult ResetearContraseña(string emailUsuario)
        {
            try
            {
                string nuevaContrasenia = _CUResetearContrasenia.ResetearContrasenia(emailUsuario);
                return Ok(nuevaContrasenia);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
