using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Charshyia.Services.Models.Products
{
    public class ProductCreateInputModel
    {
        // TODO: Add validations
        
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string ProducerId { get; set; }
    }
}
