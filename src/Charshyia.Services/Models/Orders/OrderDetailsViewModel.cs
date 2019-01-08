using Charshyia.Data.Models.Enums;
using Charshyia.Services.Models.Products;
using Charshyia.Services.Models.Shops;
using Charshyia.Services.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Charshyia.Services.Models.Orders
{
    public class OrderDetailsViewModel
    {
        public int Id { get; set; }

        public UserDetailsViewModel User { get; set; }

        public ProductDetailsViewModel Product { get; set; }

        public ShopDetailsViewModel Shop { get; set; }

        public OrderStatus Status { get; set; }
    }
}
