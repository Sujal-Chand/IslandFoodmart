using IslandFoodmart.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace IslandFoodmart.Models
{
    public class Payment
    {
        [Key]
        public int ShoppingOrderID { get; set; }
        public decimal PaymentAmount { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
        public ShoppingOrder ShoppingOrder { get; set; }
    }
}
