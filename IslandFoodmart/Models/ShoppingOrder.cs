using IslandFoodmart.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace IslandFoodmart.Models
{
    public class ShoppingOrder
    {
        [Key]
        public int ShoppingOrderID { get; set; }
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime PickupDate { get; set; }
        public decimal TotalPrice { get; set; }

        public ICollection<ShoppingItem> ShoppingItems { get; set; }
        public DatabaseUser DatabaseUser { get; set; }
        public Payment Payment { get; set; }
    }
}
