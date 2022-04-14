using Microsoft.EntityFrameworkCore;
using SiteProduct.Models;

namespace SiteProduct.Db
{
    public class Repository: DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<TypeProduct> TypeProducts { get; set; } = null!;
        public Repository(DbContextOptions<Repository> options) : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TypeProduct>().HasData(
                new TypeProduct { Id = 1, TypeName = "Прочие" },
                new TypeProduct { Id = 2, TypeName = "Книги" },
                new TypeProduct { Id = 3, TypeName = "Комплектующие для компьютеров" },
                new TypeProduct { Id = 4, TypeName = "Смартфоны" });
        }
    }
}
