using SiteProduct.Models;

namespace SiteProduct.Services
{
    public class MockProductData: IProductData
    {
        private IEnumerable<Product> _products;
        public MockProductData()
        {
            _products = new List<Product>
            {
                new Product{Id = 1, Name = "Шилдт Г. C# 4.0: Полное руководство.", Price = 750.0M, ProductionDate = DateTime.Parse("01.03.2019")},
                new Product{Id = 2, Name ="Оперативная память Kingston RAM 1x4 ГБ DDR4", Price = 1975.0M, ProductionDate = DateTime.Parse("01.05.2021")},
                new Product{Id = 3, Name ="Apple iPhone SE 64GB", Price=34789.0M, ProductionDate = DateTime.Parse("01.12.2020")}
            };
        }
        public IEnumerable<Product> GetAll()
        {
            return _products;
        }
    }
}
