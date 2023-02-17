using Microsoft.AspNetCore.Mvc.Filters;

namespace admin_cms.Models.Infraestrutura.Autenticacao
{
  public class LogadoAttribute : ActionFilterAttribute
  {



    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
      if (string.IsNullOrEmpty(filterContext.HttpContext.Request.Cookies["alunos"]))
      //if (string.IsNullOrEmpty(filterContext.HttpContext.Session.GetString("alunos")))
      {
        filterContext.HttpContext.Response.Redirect("/");
        return;
      }
      base.OnActionExecuting(filterContext);
    }
  }
}