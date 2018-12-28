using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Charshyia.Data.Models
{
    // Add profile data for application users by adding properties to the CharshyiaUser class
    public class CharshyiaUser : IdentityUser
    {
        public CharshyiaUser()
        {
            this.Shops = new HashSet<ShopUser>();
            this.Products = new HashSet<Product>();
        }

        public ICollection<ShopUser> Shops { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
