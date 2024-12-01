using Microsoft.EntityFrameworkCore;
using WebShop.DataAccess.Entities;

namespace WebShop.DataAccess;

public class WebShopDbContext : DbContext
{
    public WebShopDbContext(DbContextOptions<WebShopDbContext> options) : base(options)
    {

    }
    
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}