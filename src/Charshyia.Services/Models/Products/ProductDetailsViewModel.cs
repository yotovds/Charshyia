using Charshyia.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Charshyia.Services.Models.Products
{
    public class ProductDetailsViewModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ProducerId { get; set; }

        public CharshyiaUser Producer { get; set; }
    }
}
