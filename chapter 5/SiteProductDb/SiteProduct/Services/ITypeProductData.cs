using SiteProduct.Models;

namespace SiteProduct.Services
{
    public interface ITypeProductData
    {
        IEnumerable<TypeProduct> GetCategory();
    }
}
