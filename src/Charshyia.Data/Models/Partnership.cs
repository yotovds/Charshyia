using Charshyia.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Charshyia.Data.Models
{
    public class  Partnership
    {
        public int Id { get; set; }

        public string FromUserId { get; set; }
        public CharshyiaUser FromUser { get; set; }

        public string ToUserId { get; set; }
        public CharshyiaUser ToUser { get; set; }

        public int ShopId { get; set; }
        public Shop Shop { get; set; }

        public PartnershipStatus Status { get; set; }
    }
}
