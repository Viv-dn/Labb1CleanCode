using Moq;
using WebShop.DataAccess;
using WebShop.DataAccess.Entities;
using WebShop.Notifications;
using WebShop.UnitOfWork;

namespace WebShopTests.Tests
{
    public class UnitOfWorkTests
    {
        //private readonly DbContextOptions<WebShopDbContext> _context;
        private readonly WebShopDbContext _context;
        //private readonly IUnitOfWork _unitOfWork;

        public UnitOfWorkTests(WebShopDbContext context)
        {
            _context = context;
        }

        [Fact]
        public void NotifyProductAdded_CallsObserverUpdate()
        {
            // Arrange
            var product = new Product { Id = 1, Name = "Test" };

            // Skapar en mock av INotificationObserver
            var mockObserver = new Mock<INotificationObserver>();

            // Skapar en instans av ProductSubject och lägger till mock-observatören
            var productSubject = new ProductSubject();
            productSubject.Attach(mockObserver.Object);

            // Injicerar vårt eget ProductSubject i UnitOfWork
            var unitOfWork = new UnitOfWork(productSubject, _context);

            // Act
            unitOfWork.NotifyProductAdded(product);

            // Assert
            // Verifierar att Update-metoden kallades på vår mock-observatör
            mockObserver.Verify(o => o.Update(product), Times.Once);
        }
    }
}
