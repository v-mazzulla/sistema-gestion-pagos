using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Obligatorio.DTOs.DTOsUsuario;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.LogicaNegocio.CustomExceptions.CECompartidas;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Obligatorio.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ICULogin _CULogin;
        private readonly IConfiguration _configuration;

        public AuthController(ICULogin CULogin, IConfiguration configuration)
        {
            _CULogin = CULogin;
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Login(DTOLogin dto)
        {
            try
            {
                DTOUsuario u = _CULogin.VerificarExistencia(dto);

                // Lee la clave desde User Secrets (en desarrollo) o Variables de Entorno
                var clave = _configuration["Jwt:Key"];

                if (string.IsNullOrEmpty(clave))
                {
                    return StatusCode(500, "La clave secreta de JWT no está configurada.");
                }

                var claveCodificada = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(clave));

                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, u.Email),
                    new Claim(ClaimTypes.Role, u.Rol)
                };

                var credenciales = new SigningCredentials(claveCodificada, SecurityAlgorithms.HmacSha512Signature);

                var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: credenciales
                );

                var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(new
                {
                    Nombre = u.Nombre,
                    Apellido = u.Apellido,
                    Email = u.Email,
                    Rol = u.Rol,
                    Token = jwt
                });
            }
            catch (DatosInvalidosException)
            {
                return Conflict("Credenciales inválidas.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}