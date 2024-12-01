using WebShop.DataAccess.Entities;

namespace WebShop.DataAccess.Repositories
{
    // Gränssnitt för produktrepositoryt enligt Repository Pattern
    public interface IProductRepository : IRepository<Product>
    {
        bool InStock(Product entity, int quantity);
    }
}
