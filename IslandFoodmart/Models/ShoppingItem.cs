using IslandFoodmart.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace IslandFoodmart.Models
{
    public class ShoppingItem
    {
        [Key]
        public int ShoppingItemID { get; set; }
        public int ShoppingOrderID { get; set; }
        public int Id { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }

        public ShoppingOrder ShoppingOrder { get; set; }
       
    }
}
