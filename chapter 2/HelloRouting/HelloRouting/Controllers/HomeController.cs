using Microsoft.AspNetCore.Mvc;

namespace HelloRouting.Controllers
{
    //[Route("[controller]/[action]")]
    public class HomeController
    {
        public string Index(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return $"Привет из контроллера.";
            }
            else
            {
                return $"Привет! Это {id}.";
            }
        }

        public string Default(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return $"Привет из контроллера.";
            }
            else
            {
                return $"Привет! Это {id}.";
            }
        }
    }
}
