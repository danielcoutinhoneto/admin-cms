using Microsoft.AspNetCore.Mvc.Filters;

namespace admin_cms.Models.Infraestrutura.Autenticacao
{
  public class LogadoAttribute : ActionFilterAttribute
  {



    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
      if (string.IsNullOrEmpty(filterContext.HttpContext.Request.Cookies["adm_cms"]))
      {
        filterContext.HttpContext.Response.Redirect("/login");
        return;
      }
      base.OnActionExecuting(filterContext);
    }
  }
}