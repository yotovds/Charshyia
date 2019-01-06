using Charshyia.Data.Models;
using Charshyia.Services.Models.Shops;
using Charshyia.Services.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Charshyia.Services.Models.Products
{
    public class ProductDetailsViewModel
    {
        public ProductDetailsViewModel()
        {
            this.Shops = new List<ShopDetailsViewModel>();
            this.Commnets = new List<string>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string ProducerId { get; set; }

        public string Producer { get; set; }

        public ICollection<ShopDetailsViewModel> Shops { get; set; }

        public ICollection<string> Commnets { get; set; }

    }
}
