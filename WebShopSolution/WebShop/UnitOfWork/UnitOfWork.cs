using WebShop.DataAccess;
using WebShop.DataAccess.Entities;
using WebShop.DataAccess.Repositories;
using WebShop.Notifications;

namespace WebShop.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WebShopDbContext _context;
        private readonly ProductSubject _productSubject;
        

        // Hämta produkter från repository
        public IProductRepository Products { get; private set; }
        
        
        // Konstruktor används för tillfället av Observer pattern
        public UnitOfWork(ProductSubject productSubject)
        {
            Products = new ProductRepository(_context);

            // Om inget ProductSubject injiceras, skapa ett nytt
            _productSubject = productSubject ?? new ProductSubject();

            // Registrera standardobservatörer
            _productSubject.Attach(new EmailNotification());
        }

        public void NotifyProductAdded(Product product)
        {
            _productSubject.Notify(product);
        }
    }
}
