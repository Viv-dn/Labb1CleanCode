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

        // Endpoint för att hämta alla produkter
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            // Behöver använda repository via Unit of Work för att hämta produkter
            var prods = _unitOfWork.Products.GetAll();
            return Ok(prods);
        }

        // Endpoint för att lägga till en ny produkt
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            // Lägger till produkten via repository
            _unitOfWork.Products.Add(product);

            // Sparar förändringar
            _context.SaveChanges();

            // Notifierar observatörer om att en ny produkt har lagts till
            _unitOfWork.NotifyProductAdded(product);
            return Ok();
        }
    }
}
