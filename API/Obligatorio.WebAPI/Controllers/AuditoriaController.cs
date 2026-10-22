using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.DTOs.DTOsAuditoria;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUAuditoria;
using Obligatorio.LogicaNegocio.CustomExceptions.CECompartidas;

namespace Obligatorio.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditoriaController : Controller
    {
        private ICUAuditoriasDeTipoGasto _CUAuditoriasDeTipoGasto;
        public AuditoriaController(ICUAuditoriasDeTipoGasto CUAuditoriasDeTipoGasto)
        {
            _CUAuditoriasDeTipoGasto = CUAuditoriasDeTipoGasto;
        }

        
        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public IActionResult GetAuditoriasDeTipoGasto(int idTipoGasto)
        {
            try
            {
                List<DTOAuditoria> auditorias = _CUAuditoriasDeTipoGasto.AuditoriasDeTipoGasto(idTipoGasto);
                return Ok(auditorias);
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
