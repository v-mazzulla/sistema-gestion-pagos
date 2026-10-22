using Microsoft.AspNetCore.Mvc;
using Obligatorio.DTOs.DTOsTipoGasto;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUTipoGasto;
using Obligatorio.LogicaNegocio.CustomExceptions.CECompartidas;
using Obligatorio.WebApp.Filtros;

namespace Obligatorio.WebApp.Controllers
{
    public class TipoGastoController : Controller
    {
        private ICUAltaTipoGasto _CUAltaTipoGasto;
        private ICUObtenerTiposGastos _CUObtenerTiposGastos;
        private ICUObtenerTipoGasto _CUObtenerTipoGasto;
        private ICUEditarTipoGasto _CUEditarTipoGasto;
        private ICUEliminarTipoGasto _CUEliminarTipoGasto;

        public TipoGastoController(ICUAltaTipoGasto CUAltaTipoGasto, ICUObtenerTiposGastos CUObtenerTiposGastos, ICUEditarTipoGasto CUEditarTipoGasto, ICUObtenerTipoGasto CUObtenerTipoGasto, ICUEliminarTipoGasto CUEliminarTipoGasto)
        {
            _CUAltaTipoGasto = CUAltaTipoGasto;
            _CUObtenerTiposGastos = CUObtenerTiposGastos;
            _CUEditarTipoGasto = CUEditarTipoGasto;
            _CUObtenerTipoGasto = CUObtenerTipoGasto;
            _CUEliminarTipoGasto = CUEliminarTipoGasto;
        }

        private string ObtenerEmailLogueado()
        {
            return HttpContext.Session.GetString("EmailLogueado");
        }

        [LogueadoAdmin]
        public IActionResult Index()
        {
            try
            {
                List<DTOTipoGasto> listTg = _CUObtenerTiposGastos.ObtenerTiposGastos();
                if (listTg.Count() == 0)
                {
                    ViewBag.Mensaje = "No hay tipos de gasto ingresados";
                }
                return View(listTg);
            }
            catch (Exception e)
            {
                ViewBag.Mensaje = "Ha ocurrido un error, intente de nuevo mas tarde";
            }
            return View();
        }

        [LogueadoAdmin]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DTOAltaTipoGasto dto)
        {
            string emailLogueado = ObtenerEmailLogueado();
            try
            {
                _CUAltaTipoGasto.AltaTipoGasto(dto, emailLogueado);
                return RedirectToAction("Index", "TipoGasto");
            }
            catch(DatosInvalidosException e)
            {
                ViewBag.Mensaje = e.Message;
            }
            catch (Exception e)
            {
                ViewBag.Mensaje = "Ha ocurrido un error, intente de nuevo mas tarde";
            }
            return View();
        }

        [LogueadoAdmin]
        public IActionResult Edit(int id)
        {
            try
            {
                DTOTipoGasto dto = _CUObtenerTipoGasto.ObtenerTipoGasto(id);
                HttpContext.Session.SetInt32("IdTipoGastoSeleccionado", id);
                return View(dto);
            }
            catch (Exception e)
            {
                ViewBag.Mensaje = e.Message;
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit(DTOTipoGasto actualizado)
        {
            int? idTipoGasto = HttpContext.Session.GetInt32("IdTipoGastoSeleccionado");
            actualizado.Id = (int)idTipoGasto;

            try
            {
                _CUEditarTipoGasto.EditarTipoGasto(actualizado, ObtenerEmailLogueado());
                return RedirectToAction("Index", "TipoGasto");
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
                ViewBag.Mensaje = e.Message; ;
                throw;
            }
            return View();
        }

        [LogueadoAdmin]
        public IActionResult Delete(int id)
        {
            try
            {
                DTOTipoGasto buscado = _CUObtenerTipoGasto.ObtenerTipoGasto(id);
                return View(buscado);
            }
            catch (Exception e)
            {
                ViewBag.Mensaje = "Ha ocurrido un error, intente de nuevo mas tarde";
            }
            return View();
        }

        [HttpPost]
        public IActionResult Delete(DTOTipoGasto dto)
        {
            try
            {
                _CUEliminarTipoGasto.EliminarTipoGasto(dto.Id, ObtenerEmailLogueado());
                return RedirectToAction("Index", "TipoGasto");
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
                ViewBag.Mensaje = "Ha ocurrido un error, intente de nuevo mas tarde";
                //throw;
            }
            return View();
        }
    }
}
