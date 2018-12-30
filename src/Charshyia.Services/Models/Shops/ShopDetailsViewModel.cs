using Charshyia.Services.Models.Products;
using Charshyia.Services.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Charshyia.Services.Models.Shops
{
    public class ShopDetailsViewModel
    {
        public ShopDetailsViewModel()
        {
            this.Products = new List<ProductDetailsViewModel>();
            this.Producers = new List<UserDetailsViewModel>();
            //this.Comments = new HashSet<ShopComment>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string FounderId { get; set; }

        public string FounderName { get; set; }

        public ICollection<ProductDetailsViewModel> Products { get; set; }

        public ICollection<UserDetailsViewModel> Producers { get; set; }

        //public ICollection<ShopComment> Comments { get; set; }
    }
}
