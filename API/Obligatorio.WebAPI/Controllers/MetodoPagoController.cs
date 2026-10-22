using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.DTOs.DTOsMetodoPago;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUMetodoPago;

namespace Obligatorio.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MetodoPagoController : Controller
    {

        private ICUObtenerMetodosPago _CUObtenerMetodosPago;

        public MetodoPagoController(ICUObtenerMetodosPago CUObtenerMetodoPago)
        {
            _CUObtenerMetodosPago = CUObtenerMetodoPago;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetMetodosPago()
        {
            try
            {
                List<DTOMetodoPago> MetodosPago = _CUObtenerMetodosPago.ObtenerMetodosPago();
                return Ok(MetodosPago);
            }
            catch (Exception e)
            {
                return StatusCode(500,e.ToString());
            }
        }
    }
}
