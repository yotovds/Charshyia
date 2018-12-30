using Charshyia.Services.Models.Products;
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
        }

        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string PhoneNumer { get; set; }

        public ICollection<ProductDetailsViewModel> Products { get; set; }
    }
}
