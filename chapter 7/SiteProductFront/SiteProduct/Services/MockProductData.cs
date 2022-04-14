using SiteProduct.Models;

namespace SiteProduct.Services
{
    public class MockProductData: IProductData
    {
        private List<Product> _products;
        public MockProductData()
        {
            _products = new List<Product>
            {
                new Product{Id = 1, Name = "Шилдт Г. C# 4.0: Полное руководство.", Price = 750.0M, ProductionDate = DateTime.Parse("01.03.2019"), CategoryId = 2 },
                new Product{Id = 2, Name ="Оперативная память Kingston RAM 1x4 ГБ DDR4", Price = 1975.0M, ProductionDate = DateTime.Parse("01.05.2021"), CategoryId = 3},
                new Product{Id = 3, Name ="Apple iPhone SE 64GB", Price=34789.0M, ProductionDate = DateTime.Parse("01.12.2020"), CategoryId = 4}
            };
        }
        public IEnumerable<Product> GetAll()
        {
            return _products;
        }
        public Product Get(int id)
        {
            return _products.FirstOrDefault(x => x.Id.Equals(id)) ?? new Product() { Id = -1 };
        }
        public int Add(Product newProduct)
        {
            newProduct.Id = _products.Max(p => p.Id) + 1;
            _products.Add(newProduct);
            return newProduct.Id;
        }
        public void Save(Product product)
        {
            _products.Where(p => p.Id == product.Id).ToList().ForEach(x => { x.Name = product.Name; x.Price = product.Price; x.ProductionDate = product.ProductionDate; x.CategoryId = product.CategoryId; });
        }
        public void Delete(Product product)
        {
            _products.Remove(product);
        }
    }
}
