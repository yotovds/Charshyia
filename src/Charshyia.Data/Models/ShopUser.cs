using System;
using System.Collections.Generic;
using System.Text;

namespace Charshyia.Data.Models
{
    public class ShopUser
    {
        public string ProducerId { get; set; }
        public CharshyiaUser Producer { get; set; }

        public int ShopId { get; set; }
        public Shop Shop { get; set; }
    }
}
