using WebShop.DataAccess.Entities;
using WebShop.DataAccess.Repositories;

namespace WebShop.UnitOfWork
{
    // Gränssnitt för Unit of Work
    public interface IUnitOfWork
    {
        // Repository för produkter
        IProductRepository Products { get; }

        // Sparar förändringar (om du använder en databas)
        void NotifyProductAdded(Product product); // Notifierar observatörer om ny produkt
    }
}

