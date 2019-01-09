using Charshyia.Data.Models.Enums;
using Charshyia.Services.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Charshyia.Services.Contracts
{
    public interface ISearchService
    {
        List<ProductDetailsViewModel> Search(string productName, ProductCategory category);
    }
}
