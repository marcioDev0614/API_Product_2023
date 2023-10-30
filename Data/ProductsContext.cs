using Microsoft.EntityFrameworkCore;
using Product_API_2023_V1.Models;

namespace Product_API_2023_V1.Data
{
    public class ProductsContext : DbContext
    {
        public ProductsContext(DbContextOptions<ProductsContext> options) : base(options) 
        { 
            
        }  
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true)
            .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DataBase"));
        }

        public DbSet<Product> Products { get; set; }
    }
}
