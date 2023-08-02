using System.ComponentModel.DataAnnotations;

namespace IslandFoodmart.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [Display(Name = "Category Name")]
        [Required]
        public int CategoryID { get; set; }

        [Display(Name = "Product Name")]
        [Required]
        public string ProductName { get; set; }

        [Display(Name ="Product Image")]
        [Required]
        public string ImagePath { get; set; }

        [Display(Name = "Price")]
        [Required]
        public decimal ProductPrice { get; set; }

        [Display(Name = "Stock")]
        [Required]
        public int ProductStock { get; set; }

        public Category Category  { get; set; }
        public ICollection<ShoppingItem> ShoppingItems { get; set; }
    }
}
