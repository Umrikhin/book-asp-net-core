using Microsoft.EntityFrameworkCore;
using MobileDevices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDevices
{
    //Установите через Консоль диспетчера пакетов
    //Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 6.0.1
    //Install-Package Microsoft.EntityFrameworkCore.Tools -Version 6.0.1
    public class Repository : DbContext
    {
        public DbSet<MobileDevice> MobileDevices { get; set; }
        public Repository()
        {
            //Создаем DbSet<TEntity>, который можно использовать для запроса и сохранения экземпляров MobileDevice.
            MobileDevices = Set<MobileDevice>();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MdDatabase;Trusted_Connection=True;");
        }
    }
}
