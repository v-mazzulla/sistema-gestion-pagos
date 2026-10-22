using Microsoft.AspNetCore.Mvc;
using Obligatorio.WebApp.Models;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUTipoGasto;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUMetodoPago;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUPago;
using Obligatorio.DTOs.DTOsPago;
using Obligatorio.LogicaNegocio.CustomExceptions.CECompartidas;
using Obligatorio.WebApp.Filtros;

namespace Obligatorio.WebApp.Controllers
{
    public class PagoController : Controller
    {
        private ICUObtenerTiposGastos _CuObtenerTiposGasto;
        private ICUObtenerMetodosPago _CuObtenerMetodosPago;
        private ICUAltaPago _CuAltaPago;
        private ICUObtenerPagosMes _CuObtenerPagosMes;

        public PagoController(ICUObtenerTiposGastos CuObtenerTiposGasto,
                ICUObtenerMetodosPago CuObtenerMetodosPago,
                ICUAltaPago CuAltaPago, ICUObtenerPagosMes CuObtenerPagosMes)
        {
            _CuObtenerTiposGasto = CuObtenerTiposGasto;
            _CuObtenerMetodosPago = CuObtenerMetodosPago;
            _CuAltaPago = CuAltaPago;
            _CuObtenerPagosMes = CuObtenerPagosMes;
        }
        public IActionResult Index()
        {
            return View();
        }

        private string ObtenerEmailLogueado()
        {
            return HttpContext.Session.GetString("EmailLogueado");
        }

        [Logueado]
        [HttpGet]
        public IActionResult Create() {
            AltaPagoVM vm = new AltaPagoVM();
            vm.TiposDeGasto = _CuObtenerTiposGasto.ObtenerTiposGastos();
            vm.MetodosPago = _CuObtenerMetodosPago.ObtenerMetodosPago();

            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(AltaPagoVM vm)
        {
            try
            {
                string emailLogueado = ObtenerEmailLogueado();
                _CuAltaPago.AltaPago(vm.Dto, emailLogueado);
                ViewBag.msgS = "Alta Correcta";

            }
            catch(DatosInvalidosException e)
            {
                ViewBag.Mensaje = e.Message;
            }
            catch (Exception e)
            {
                ViewBag.Mensaje = "Ha ocurrido un error, intente de nuevo mas tarde";
            }

            vm.TiposDeGasto = _CuObtenerTiposGasto.ObtenerTiposGastos();
            vm.MetodosPago = _CuObtenerMetodosPago.ObtenerMetodosPago();
            return View(vm);
        }

        [LogueadoGerente]

        [HttpGet]
        public IActionResult List()
        {
            return View();
        }

        [HttpPost]
        public IActionResult List(string mesFiltro)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(mesFiltro))
                {
                    string[] subs = mesFiltro.Split('-');
                    int y = int.Parse(subs[0]);
                    int m = int.Parse(subs[1]);

                    List<DTOPago> listP = _CuObtenerPagosMes.ObtenerPagosMes(m, y);

                    if (listP.Count() == 0)
                    {
                        ViewBag.Mensaje = "No hay pagos ingresados en el mes dado";
                    }
                    return View(listP);
                }
                else
                {
                    ViewBag.Mensaje = "Debe ingresar una fecha";
                }                
            }
            catch (Exception e)
            {
                ViewBag.Mensaje = e.Message;
            }
            return View();

        }
    }
}
