using System;
using System.Collections.Generic;
using System.Text;

namespace Charshyia.Data.Models
{
    public class ShopComment
    {
        // TODO: Use BaseComment class
        public int Id { get; set; }

        public int ShopId { get; set; }

        public Shop Shop { get; set; }

        public string CommentContent { get; set; }
    }
}
