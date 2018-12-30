using System;
using System.Collections.Generic;
using System.Text;

namespace Charshyia.Data.Models
{
    public class ProductComment
    {
        // TODO: Use BaseComment class
        public int Id { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public string Content { get; set; }
    }
}
