using IslandFoodmart.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace IslandFoodmart.Models
{
    public class ShoppingItem
    {
        [Key]
        public int ShoppingItemID { get; set; }

        public int ShoppingOrderID { get; set; }

        [Display(Name = "Product Name")]
        [Required]
        public int ProductID { get; set; }

        [Display(Name = "Product Name")]
        [Required]
        public int Quantity { get; set; }

        public Product Product { get; set; }
        public ShoppingOrder ShoppingOrder { get; set; }
       
    }
}
