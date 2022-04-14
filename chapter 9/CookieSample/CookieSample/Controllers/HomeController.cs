using Microsoft.AspNetCore.Mvc;

namespace CookieSample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //Чтение cookie
            string cookieValueFromReq = Get("NamePerson");
            ViewBag.CookieValue = cookieValueFromReq;
            return View();
        }
        public IActionResult Delete()
        {   
            //Удаление cookie
            Remove("NamePerson");
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            //Установка cookie  
            Set("NamePerson", "Bill Gates", 10);
            return RedirectToAction("Index");
        }
        string Get(string key)
        {
            return Request.Cookies[key] ?? string.Empty;  
        }
        void Set(string key, string value, int? expireTime)
        {
            CookieOptions option = new CookieOptions();
            if (expireTime.HasValue)
                option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
            else
                option.Expires = DateTime.Now.AddMilliseconds(10);
            Response.Cookies.Append(key, value, option);
        }
        void Remove(string key)
        {
            Response.Cookies.Delete(key);
        }
    }
}
