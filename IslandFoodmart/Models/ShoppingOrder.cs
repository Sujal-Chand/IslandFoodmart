using IslandFoodmart.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace IslandFoodmart.Models
{
    public class ShoppingOrder
    {
        [Key]
        public int ShoppingCartID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime PickupDate { get; set; }
        public decimal TotalPrice { get; set; }

        public ShoppingItem ShoppingItem { get; set; }
    }
}
