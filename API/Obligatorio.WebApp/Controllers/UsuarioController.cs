using Microsoft.AspNetCore.Mvc;
using Obligatorio.DTOs.DTOsPago;
using Obligatorio.DTOs.DTOsUsuario;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUEquipo;
using Obligatorio.LogicaAplicacion.ICasosUso.ICURolUsuario;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.LogicaNegocio.CustomExceptions.CECompartidas;
using Obligatorio.WebApp.Filtros;

namespace Obligatorio.WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        private ICUAltaUsuario _CUAltaUsuario;
        private ICUObtenerRoles _CUObtenerRoles;
        private ICUObtenerEquipos _CUObtenerEquipos;
        private ICUUsuariosXMontoPago _CUUsuariosXMontoPago;

        public UsuarioController(ICUAltaUsuario CUAltaUsuario, ICUObtenerRoles CUObtenerRoles,
                                ICUObtenerEquipos CUObtenerEquipos, ICUUsuariosXMontoPago CUUsuariosXMontoPago)
        {
            _CUAltaUsuario = CUAltaUsuario;
            _CUObtenerRoles = CUObtenerRoles;
            _CUObtenerEquipos = CUObtenerEquipos;
            _CUUsuariosXMontoPago = CUUsuariosXMontoPago;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Lo comente luego de cambiar el dto solo para que me dejara de saltar el error en la error list
        /*
                [LogueadoAdminOGerente]
                public IActionResult Create()
                {
                    DTOAltaUsuario dtoIda = new DTOAltaUsuario();
                    dtoIda.Rol = _CUObtenerRoles.ObtenerRoles();
                    dtoIda.Equipo = _CUObtenerEquipos.ObtenerEquipos();
                    return View(dtoIda);
                }

                [HttpPost]
                public IActionResult Create(DTOAltaUsuario dto)
                {
                    try
                    {
                        _CUAltaUsuario.AltaUsuario(dto);
                        ViewBag.Mensaje = "Alta exitosa";
                    }
                    catch (DatosInvalidosException e)
                    {
                        ViewBag.Mensaje = e.Message;
                    }
                    DTOAltaUsuario dtoVuelta = new DTOAltaUsuario();
                    dtoVuelta.Rol = _CUObtenerRoles.ObtenerRoles();
                    dtoVuelta.Equipo = _CUObtenerEquipos.ObtenerEquipos();
                    return View(dtoVuelta);
                }
        */


        [LogueadoGerente]
        [HttpGet]
        public IActionResult List()
        {
            return View();
        }

        [HttpPost]
        public IActionResult List(double montoFiltro)
        {
            try
            {
                if (montoFiltro <= 0)
                {
                    ViewBag.Mensaje = "Ingrese un monto";
                }
                else
                {
                    List<DTOUsuario> listU = _CUUsuariosXMontoPago.UsuariosXMontoPago(montoFiltro);
                    if (listU.Count() == 0)
                    {
                        ViewBag.Mensaje = "No hay usuarios que cuenten con pagos mayores a $" + montoFiltro;
                    }
                    return View(listU);
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
