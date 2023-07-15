using IslandFoodmart.Areas.Identity.Data;

namespace IslandFoodmart.Models
{
    public class ShoppingOrder
    {
        public int ShoppingOrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime PickupDate { get; set; }

        public ICollection<DatabaseUser> DatabaseUser { get; set; }
        public ICollection<ShoppingCart> ShoppingCart { get; set; }
        public ICollection<Payment> Payment { get; set; }
    }
}
