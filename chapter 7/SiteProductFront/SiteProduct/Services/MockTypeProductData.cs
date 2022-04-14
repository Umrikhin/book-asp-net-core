using SiteProduct.Models;

namespace SiteProduct.Services
{
    public class MockTypeProductData: ITypeProductData
    {
        private List<TypeProduct> _typeProducts;
        public MockTypeProductData()
        {
            _typeProducts = new List<TypeProduct>
            {
                new TypeProduct{Id = 1, TypeName = "Прочие"},
                new TypeProduct{Id = 2, TypeName = "Книги"},
                new TypeProduct{Id = 3, TypeName = "Комплектующие для компьютеров"},
                new TypeProduct{Id = 4, TypeName = "Смартфоны"}
            };
        }
        public IEnumerable<TypeProduct> GetCategory()
        {
            return _typeProducts;
        }
    }
}
