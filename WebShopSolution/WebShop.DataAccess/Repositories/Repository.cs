using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.CompilerServices;
using WebShop.DataAccess;

namespace WebShop.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly WebShopDbContext _context;
        private readonly DbSet<T> _entity;

        public Repository(WebShopDbContext context)
        {
            _context = context;
            _entity = context.Set<T>();
        }

        public T GetById(int id)
        {
            return _entity.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _entity.ToList();
        }

        public void Add(T entity)
        {
            _entity.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _entity.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = _entity.Find(id);
            if (product != null)
            {
                _entity.Remove(product);
            }
            _context.SaveChanges();
        }
    }
}
