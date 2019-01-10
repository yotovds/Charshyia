using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Charshyia.Services.Models.Shops
{
    public class ShopCreateInputModel
    {
        [Required]
        [Display(Name = "shop name")]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 4)]
        [DataType(DataType.Text)]
        public string Name { get; set; }
    }
}
