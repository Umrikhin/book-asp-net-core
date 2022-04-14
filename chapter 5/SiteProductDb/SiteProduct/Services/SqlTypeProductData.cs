using SiteProduct.Db;
using SiteProduct.Models;

namespace SiteProduct.Services
{
    public class SqlTypeProductData : ITypeProductData
    {
        private Repository _db;
        public SqlTypeProductData(Repository db)
        {
            _db = db;
        }
        public IEnumerable<TypeProduct> GetCategory()
        {
            return _db.TypeProducts.ToList();
        }
    }
}
