using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Authorization.Utils
{
    public class AuthorizationFilter : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            bool exists_auth = false;
            if (context.HttpContext.Session.GetString("UserId") != null)
            {
                exists_auth = true;
            }
            else
            {
                if (context.HttpContext.Request.Cookies.ContainsKey("UserId"))
                {
                    var cookie = context.HttpContext.Request.Cookies["UserId"] ?? string.Empty;
                    context.HttpContext.Session.SetString("UserId", cookie);
                    exists_auth = true;
                }
            }
            if (!exists_auth)
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Login" }));
            else
                await next();
        }
    }
}
