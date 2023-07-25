using IslandFoodmart.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace IslandFoodmart.Models
{
    public class ShoppingOrder
    {
        
        public int ShoppingOrderID { get; set; }
        public string UserName { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime PickupDate { get; set; }
        public decimal PriceTotal { get; set; }
		public Payment Payment { get; set; }
		public ICollection<ShoppingItem> ShoppingItems { get; set; }
       
    }
}
