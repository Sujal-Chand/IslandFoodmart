using IslandFoodmart.Areas.Identity.Data;
using MessagePack;

namespace IslandFoodmart.Models
{
    public class ShoppingCart
    {
        public int ShoppingCartID { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
        public ICollection<DatabaseUser> DatabaseUser { get; set; }
        public ICollection<Product> Product { get; set; }
    }
}
