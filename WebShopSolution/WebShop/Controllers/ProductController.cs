using Microsoft.AspNetCore.Mvc;
using WebShop.DataAccess;
using WebShop.DataAccess.Entities;
using WebShop.UnitOfWork;

namespace WebShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly WebShopDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWorkRepo, WebShopDbContext context)
        {
            _unitOfWork = unitOfWorkRepo;
            _context = context;
        }

        // Endpoint f�r att h�mta alla produkter
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            // Beh�ver anv�nda repository via Unit of Work f�r att h�mta produkter
            var prods = _unitOfWork.Products.GetAll();
            return Ok(prods);
        }

        // Endpoint f�r att l�gga till en ny produkt
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            // L�gger till produkten via repository
            _unitOfWork.Products.Add(product);

            // Sparar f�r�ndringar
            _context.SaveChanges();

            // Notifierar observat�rer om att en ny produkt har lagts till
            _unitOfWork.NotifyProductAdded(product);
            return Ok();
        }
    }
}
