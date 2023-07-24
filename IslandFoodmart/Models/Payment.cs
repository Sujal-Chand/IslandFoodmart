using IslandFoodmart.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace IslandFoodmart.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public decimal PaymentAmount { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
        public ICollection<DatabaseUser> DatabaseUser { get; set; }
    }
}
