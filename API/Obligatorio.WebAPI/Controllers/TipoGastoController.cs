using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.DTOs.DTOsTipoGasto;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUTipoGasto;

namespace Obligatorio.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TipoGastoController : Controller
    {
        
        private ICUObtenerTiposGastos _CUObtenerTiposGastos;

        public TipoGastoController(ICUObtenerTiposGastos CUObtenerTiposGastos)
        {
            _CUObtenerTiposGastos = CUObtenerTiposGastos;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetTiposPago()
        {
            try
            {
                List<DTOTipoGasto> TiposGastos = _CUObtenerTiposGastos.ObtenerTiposGastos();
                return Ok(TiposGastos);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.ToString());
            }
        }
    }
}
