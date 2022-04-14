using Microsoft.AspNetCore.Mvc;
using SiteProduct.Models;
using SiteProduct.Services;

namespace SiteProduct.Controllers
{
    public class HomeController : Controller
    {
        private IProductData _products;
        public HomeController(IProductData products)
        {
            _products = products;
        }
        public ViewResult Index()
        {
            return View(_products.GetAll());
        }

        /*
        public ObjectResult Index()
        {
            var model = new Product
            {
                Id = 1,
                Name = "Шилдт Г. C# 4.0: Полное руководство.",
                Price = 750.0M,
                ProductionDate = DateTime.Parse("01.03.2019")
            };
            return new ObjectResult(model);
        }
        */

        /*
        public ViewResult Index()
        {
            var model = new Product
            {
                Id = 1,
                Name = "Шилдт Г. C# 4.0: Полное руководство.",
                Price = 750.0M,
                ProductionDate = DateTime.Parse("01.03.2019")
            };
            return View(model);
        }
        */

        /*
        public ViewResult Index()
        {
            var model = new List<Product>
            {
                new Product{Id = 1, Name = "Шилдт Г. C# 4.0: Полное руководство.", Price = 750.0M, ProductionDate = DateTime.Parse("01.03.2019")},
                new Product{Id = 2, Name ="Оперативная память Kingston RAM 1x4 ГБ DDR4", Price = 1975.0M, ProductionDate = DateTime.Parse("01.05.2021")},
                new Product{Id = 3, Name ="Apple iPhone SE 64GB", Price=34789.0M, ProductionDate = DateTime.Parse("01.12.2020")}
            };
            return View(model);
        }
        */


    }
}
