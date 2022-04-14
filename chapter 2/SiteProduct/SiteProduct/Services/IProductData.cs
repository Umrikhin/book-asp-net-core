using SiteProduct.Models;

namespace SiteProduct.Services
{
    public interface IProductData
    {
        IEnumerable<Product> GetAll();
    }
}
