using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.SQL
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {
        } 

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> Categories { get; set; }

        public System.Data.Entity.DbSet<MyShop.Core.Models.BaseEntity> BaseEntities { get; set; }
    }
}
