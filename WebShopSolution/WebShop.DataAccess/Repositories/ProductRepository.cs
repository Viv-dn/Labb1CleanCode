using Microsoft.EntityFrameworkCore;
using WebShop.DataAccess.Entities;

namespace WebShop.DataAccess.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    //private readonly WebShopDbContext _context;
    private readonly DbSet<Product> _entity;

    public ProductRepository(WebShopDbContext context) : base(context)
    {
    }

    public IEnumerable<Product> GetAll()
    {
        return _entity.ToList();
    }

    //GetByID


    public void Add(Product entity)
    {
        if (entity is null)
        {
            throw new ArgumentException(nameof(entity));
        }

        _entity.Add(entity);
    }

    public void Update(Product entity)
    {
        if (entity is null)
        {
            throw new ArgumentException(nameof(entity));
        }

        _entity.Update(entity);
    }

    public void Delete(int id)
    {
        var prod = _entity.Find(id);
        if (prod is null)
        {
            throw new KeyNotFoundException();
        }

        _entity.Remove(prod);
    }

    public bool InStock(Product entity, int quantity)
    {
        throw new NotImplementedException();
    }
}