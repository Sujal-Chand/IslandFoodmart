using IslandFoodmart.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace IslandFoodmart.Models
{
    public class ShoppingOrder
    {

        [Display(Name = "Shopping Order ID")]
        public int ShoppingOrderID { get; set; }

        public string UserName { get; set; }

        [Display(Name = "Customer")]
        public string ShoppingFirstName { get; set; }

        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Pick up date")]
        public DateTime PickupDate { get; set; }

        [Display(Name = "Total Price")]
        public decimal PriceTotal { get; set; }

		public Payment Payment { get; set; }
		public ICollection<ShoppingItem> ShoppingItems { get; set; }
       
    }
}
