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
            this.Comments = new HashSet<ProductComment>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string ProducerId { get; set; }

        public CharshyiaUser Producer { get; set; }

        public ICollection<ShopProduct> Shops { get; set; }

        public ICollection<ProductComment> Comments { get; set; }
    }
}
