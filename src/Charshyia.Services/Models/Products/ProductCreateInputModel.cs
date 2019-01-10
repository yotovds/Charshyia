using Charshyia.Data.Models.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Charshyia.Services.Models.Products
{
    public class ProductCreateInputModel
    {
        // TODO: Add validations
        
        public int Id { get; set; }

        [Required]
        [Display(Name = "product name")]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 4)]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "product price")]
        [DataType(DataType.Currency)]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid price")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "product description")]
        [StringLength(250, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 25)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile Image { get; set; }

        public string ProducerId { get; set; }

        [Required]
        [EnumDataType(typeof(ProductCategory))]
        public ProductCategory Category { get; set; }
    }
}
