using System;
using System.Collections.Generic;
using System.Text;

namespace Charshyia.Data.Models
{
    public class ShopProduct
    {
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int ShopId { get; set; }

        public Shop Shop { get; set; }
    }
}
