namespace WebShop.DataAccess.Entities
{
    // Produktmodellen representerar en produkt i webbshoppen
    public class Product
    {
        public int Id { get; set; } // Unikt ID f�r produkten
        public string Name { get; set; } // Namn p� produkten
        public int Price { get; set; }
        public bool InStock { get; set; }
    }
}