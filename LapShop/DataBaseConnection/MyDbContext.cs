using LapShop.Models;
using Microsoft.EntityFrameworkCore;

namespace LapShop.DataBaseConnection
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) 
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Model> Models { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Series> Series { get; set; }
        
        public DbSet<ConfigurationItem> ConfigurationItems { get; set; }   

        public DbSet<Order> Orders { get; set; }

        public DbSet<ModelConfigurationItem> ModelConfigurations { get; set; }
    }
}
