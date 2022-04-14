using SiteProduct.Models;

namespace SiteProduct.Services
{
    public interface IProductData
    {
        IEnumerable<Product> GetAll();
        public Product Get(int id);
        int Add(Product newProduct);
        void Save(Product product);
    }
}
