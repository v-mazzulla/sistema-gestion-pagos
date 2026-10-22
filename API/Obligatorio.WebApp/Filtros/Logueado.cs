using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Obligatorio.WebApp.Filtros
{
    public class Logueado : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string rol = context.HttpContext.Session.GetString("RolLogueado");

            if (rol is null)
            {
                context.Result = new RedirectToActionResult("login", "auth", null);
            }

            base.OnActionExecuting(context);
        }
    }
}
