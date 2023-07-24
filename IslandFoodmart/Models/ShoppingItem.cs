using IslandFoodmart.Areas.Identity.Data;
using MessagePack;

namespace IslandFoodmart.Models
{
    public class ShoppingItem
    {
        public int ShoppingCartID { get; set; }
        public int Id { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
       
    }
}
