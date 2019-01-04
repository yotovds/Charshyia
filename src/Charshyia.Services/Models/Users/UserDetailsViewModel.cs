using Charshyia.Data.Models;
using Charshyia.Services.Models.Products;
using Charshyia.Services.Models.Shops;
using System;
using System.Collections.Generic;
using System.Text;

namespace Charshyia.Services.Models.Users
{
    public class UserDetailsViewModel
    {
        public UserDetailsViewModel()
        {
            this.Products = new List<ProductDetailsViewModel>();
            this.Shops = new List<ShopDetailsViewModel>();
        }

        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public ICollection<ProductDetailsViewModel> Products { get; set; }

        public ICollection<ShopDetailsViewModel> Shops { get; set; }

        //public ICollection<Partnership> Partnerships { get; set; }
    }
}
