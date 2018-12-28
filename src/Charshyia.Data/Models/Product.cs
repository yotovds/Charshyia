using System;
using System.Collections.Generic;
using System.Text;

namespace Charshyia.Data.Models
{
    public class Product
    {
        public Product()
        {
            this.Shops = new HashSet<ShopProduct>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ProducerId { get; set; }

        public CharshyiaUser Producer { get; set; }

        public ICollection<ShopProduct> Shops { get; set; }
    }
}
