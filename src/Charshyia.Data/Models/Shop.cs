using System;
using System.Collections.Generic;
using System.Text;

namespace Charshyia.Data.Models
{
    public class Shop
    {
        public Shop()
        {
            this.Products = new HashSet<ShopProduct>();
            this.Producers = new HashSet<ShopUser>();
            this.Comments = new HashSet<ShopComment>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string FounderId { get; set; }

        public CharshyiaUser Founder { get; set; }

        public ICollection<ShopProduct> Products { get; set; }

        public ICollection<ShopUser> Producers { get; set; }

        public ICollection<ShopComment> Comments { get; set; }
    }
}
