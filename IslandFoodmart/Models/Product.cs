using System.ComponentModel.DataAnnotations;

namespace IslandFoodmart.Models
{
    public class Product
    {
        public int ProductID { get; set; }
		public int CategoryID { get; set; }
        [Required]
		public string ProductName { get; set; }
        public string ImagePath { get; set; }
        [Required]
        public decimal ProductPrice { get; set; }
        public int ProductStock { get; set; }
        public Category Category  { get; set; }
    }
}
