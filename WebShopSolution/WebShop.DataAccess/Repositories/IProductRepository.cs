namespace WebShop.Repositories
{
    // Gränssnitt för produktrepositoryt enligt Repository Pattern
    public interface IProductRepository : IRepository<Product>
    {
        bool InStock(Product entity, int quantity);
    }
}
