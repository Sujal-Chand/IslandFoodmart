namespace IslandFoodmart.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public int ProductPrice { get; set; }
        public int ProductStock { get; set; }
        public ICollection<Category> Category { get; set; }
    }
}
