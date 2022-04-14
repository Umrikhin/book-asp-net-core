using SiteProduct.Db;
using SiteProduct.Models;

namespace SiteProduct.Services
{
    public class SqlProductData : IProductData
    {
        private Repository _db;
        public SqlProductData(Repository db)
        {
            _db = db;
        }
        public int Add(Product newProduct)
        {
            _db.Add(newProduct);
            _db.SaveChanges();
            return newProduct.Id;
        }
        public Product Get(int id)
        {
            return _db.Find<Product>(id) ?? new Product() { Id = -1 };
        }
        public IEnumerable<Product> GetAll()
        {
            return _db.Products.ToList();
        }
        public void Save(Product product)
        {
            _db.Update(product);
            _db.SaveChanges();
        }
        public void Delete(Product product)
        {
            _db.Remove(product);
            _db.SaveChanges();
        }
    }
}
