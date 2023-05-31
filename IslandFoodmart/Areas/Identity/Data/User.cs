using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace IslandFoodmart.Areas.Identity.Data
{
    public class User : IdentityUser
    {
        public string UserName { get; set; }
    }
}
