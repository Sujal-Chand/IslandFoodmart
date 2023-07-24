using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IslandFoodmart.Models;
using Microsoft.AspNetCore.Identity;

namespace IslandFoodmart.Areas.Identity.Data
{
    public class DatabaseUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<ShoppingOrder> ShoppingOrders { get; set; }
    }
}
