using IslandFoodmart.Areas.Identity.Data;

namespace IslandFoodmart.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public int PaymentAmount { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
        public ICollection<DatabaseUser> DatabaseUser { get; set; }
    }
}
