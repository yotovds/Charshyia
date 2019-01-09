using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Charshyia.Data;
using Charshyia.Data.Models.Enums;
using Charshyia.Services.Contracts;
using Charshyia.Services.Models.Products;

namespace Charshyia.Services
{
    public class SearchService : BaseService, ISearchService
    {
        public SearchService(CharshyiaDbContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }

        public List<ProductDetailsViewModel> Search(string productName, ProductCategory category)
        {
            var results = this.DbContext
                .Products
                .Where(p => p.Name.Contains(productName) && p.Category == category)
                .ToList();

            return this.Mapper.Map<List<ProductDetailsViewModel>>(results);
        }
    }
}
