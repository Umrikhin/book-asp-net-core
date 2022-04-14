using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.RegularExpressions;

namespace FiltersSample.Utils
{
    public class BrowserFilterAsync : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            string userAgent = context.HttpContext.Request.Headers["User-Agent"].ToString();
            
            //Проверяем агента для IE и старого Edge
            if (Regex.IsMatch(userAgent, "MSIE|Trident|Edge"))
                context.Result = new ObjectResult("Ваш браузер устарел!");
            else
                await next();  // передаем управление следующему фильтру при отсутствии других фильтров 
        }
    }
    public class SimpleFilterAsync : Attribute, IAsyncActionFilter
    {
        string _user;
        public SimpleFilterAsync(string user)
        {
            _user = user;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (_user.ToLower().Contains("admin"))
                context.Result = new ObjectResult("Привет, Админ!");
            else
                await next();  // передаем управление следующему фильтру при отсутствии других фильтров 
        }
    }
    public class ConfigFilterAsync : Attribute, IAsyncActionFilter
    {
        IConfiguration _config;
        public ConfigFilterAsync(IConfiguration config)
        {
            _config = config;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (_config["CodeCountry"].ToLower() != "rus")
                context.Result = new ObjectResult("Доступ запрещен!");
            else
                await next();  // передаем управление следующему фильтру при отсутствии других фильтров 
        }
    }
}
