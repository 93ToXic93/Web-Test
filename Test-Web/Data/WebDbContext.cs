using Microsoft.EntityFrameworkCore;
using Test_Web.Data.Models;
using Test_Web.Models;

namespace Test_Web.Data
{
    public class WebDbContext : DbContext
    {
        public WebDbContext(DbContextOptions<WebDbContext> options)
            : base(options)
        {

        }

        public DbSet<Product> Products { get; set; } = null!;
    }
}
