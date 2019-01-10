using Charshyia.Data.Models.Enums;
using Charshyia.Services.Models.Products;
using Charshyia.Services.Models.Shops;
using Charshyia.Services.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Charshyia.Services.Models.Orders
{
    public class OrderDetailsViewModel
    {
        public int Id { get; set; }

        [Required]
        public UserDetailsViewModel User { get; set; }

        [Required]
        public ProductDetailsViewModel Product { get; set; }

        [Required]
        public ShopDetailsViewModel Shop { get; set; }

        [Required]
        public OrderStatus Status { get; set; }
    }
}
