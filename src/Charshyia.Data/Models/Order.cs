using Charshyia.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Charshyia.Data.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public CharshyiaUser User { get; set; }

        public int ShopId { get; set; }

        public Shop Shop { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public OrderStatus Status { get; set; }

        public string ProducerMessage { get; set; }
    }
}
