using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.DTOs.DTOsPago;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUPago;
using Obligatorio.LogicaNegocio.CustomExceptions.CECompartidas;
using Obligatorio.LogicaNegocio.CustomExceptions.CEPago;
using System.Security.Claims;

namespace Obligatorio.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        private ICUObtenerPago _CUObtenerPago;
        private ICUAltaPago _CUAltaPago;

        public PagoController(ICUObtenerPago CUObtenerPago, ICUAltaPago CUAltaPago)
        {
            _CUObtenerPago = CUObtenerPago;
            _CUAltaPago = CUAltaPago;
        }

        [HttpGet("{id}")]
        public ActionResult GetPago(int id)
        {
            try
            {
                DTOPago pago = _CUObtenerPago.ObtenerPago(id);
                return Ok(pago);
            }
            catch (PagoNoEncontradoException e)
            {
                return StatusCode(404, $"No se encontro un pago con id {id}");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.ToString());
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(DTOAltaPago dto)
        {
            try
            {
                string email = User.FindFirst(ClaimTypes.Email).Value;

               
                _CUAltaPago.AltaPago(dto,email);
                return NoContent();
             

            }
            catch (DatosInvalidosException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.ToString());
            }
        }
    }
}
