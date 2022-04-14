using Microsoft.AspNetCore.Mvc;

namespace SiteProduct.Controllers
{
    //[NonController] 
    public class ProductController: Controller
    {
        public ContentResult Name()
        {
            return Content("Шилдт Г. C# 4.0: Полное руководство.");
        }

        //[NonAction]
        //[ActionName("Hello")]
        [HttpGet]
        //[HttpPost]
        public IActionResult Index()
        {
            return Content("Привет из метода /Product/Index");
        }
    }
}
