using Microsoft.Data.SqlClient;
using SiteProduct.Models;
using Dapper;
using System.Data;

namespace SiteProduct.Services
{
    public class DapperProductData : IProductData
    {
        private string cn;
        public DapperProductData(IConfiguration conf)
        {
            cn = conf.GetSection("ConnectionStrings")["DefaultConnection"];
        }
        public int Add(Product newProduct)
        {
            using (IDbConnection db = new SqlConnection(cn))
            {
                // если мы хотим получить id добавленной записи
                var sqlQuery = "INSERT INTO Products (Name, Price, ProductionDate, CategoryId) VALUES(@Name, @Price, @ProductionDate, @CategoryId); SELECT CAST(SCOPE_IDENTITY() as int)";
                int? productId = db.Query<int>(sqlQuery, newProduct).FirstOrDefault();
                newProduct.Id = productId.Value;
            }
            return newProduct.Id;
        }
        public void Delete(Product product)
        {
            using (IDbConnection db = new SqlConnection(cn))
            {
                var sqlQuery = "DELETE FROM Products WHERE Id = @id";
                db.Execute(sqlQuery, new { product.Id });
            }
        }
        public Product Get(int id)
        {
            using (IDbConnection db = new SqlConnection(cn))
            {
                return db.Query<Product>("SELECT * FROM Products WHERE Id = @id", new { id }).FirstOrDefault() ?? new Product() { Id = -1 };
            }
        }
        public IEnumerable<Product> GetAll()
        {
            using (IDbConnection db = new SqlConnection(cn))
            {
                return db.Query<Product>("SELECT * FROM Products").ToList();
            }
        }
        public void Save(Product product)
        {
            using (IDbConnection db = new SqlConnection(cn))
            {
                var sqlQuery = "UPDATE Products SET Name = @Name, Price = @Price, ProductionDate = @ProductionDate, CategoryId = @CategoryId WHERE Id = @Id";
                db.Execute(sqlQuery, product);
            }
        }
    }
}
