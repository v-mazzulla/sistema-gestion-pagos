using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Obligatorio.WebApp.Filtros
{
    public class LogueadoAdmin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string rol = context.HttpContext.Session.GetString("RolLogueado");

            if (rol is null || rol != "Administrador")
            {
                context.Result = new RedirectToActionResult("login", "auth", null);
            }

                base.OnActionExecuting(context);
        }
    }
}
