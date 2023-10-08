using System.ComponentModel.DataAnnotations;

namespace IslandFoodmart.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
