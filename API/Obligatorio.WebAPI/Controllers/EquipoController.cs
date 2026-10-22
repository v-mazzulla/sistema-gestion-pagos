using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.DTOs.DTOsEquipo;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUEquipo;
using Obligatorio.LogicaNegocio.CustomExceptions.CECompartidas;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipoController : Controller
    {
        private ICUEquiposPagoUnicoMayor _CUEquiposPagoUnicoMayor;
        public EquipoController(ICUEquiposPagoUnicoMayor CUEquiposPagoUnicoMayor)
        {
            _CUEquiposPagoUnicoMayor = CUEquiposPagoUnicoMayor;
        }

        [Authorize(Roles = "Gerente")]
        [HttpGet]
        public IActionResult GetEquiposPagoUnicoMayor(int monto)
        {
            try
            {
                List<DTOEquipo> equipos = _CUEquiposPagoUnicoMayor.ObtenerEquiposConPagoUnicoMayor(monto);
                return Ok(equipos);
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
