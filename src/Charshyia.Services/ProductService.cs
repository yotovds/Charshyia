using AutoMapper;
using Charshyia.Data;
using Charshyia.Data.Models;
using Charshyia.Services.Contracts;
using Charshyia.Services.Models;
using Charshyia.Services.Models.Products;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Charshyia.Services.Models.Shops;

namespace Charshyia.Services
{
    public class ProductService : BaseService, IProductService
    {
        public ProductService(CharshyiaDbContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }

        public async Task<int> AddProductAsync(ProductCreateInputModel inputModel, string producerId)
        {
            var product = this.Mapper.Map<Product>(inputModel);
            product.ProducerId = producerId;
            await this.DbContext.Products.AddAsync(product);
            await this.DbContext.SaveChangesAsync();

            return product.Id;
        }

        public async Task<ProductDetailsViewModel> GetProductByIdAsync(int productId)
        {
            var product = await this.DbContext
                .Products
                .Include(p => p.Producer)
                .Where(p => p.Id == productId)
                .FirstOrDefaultAsync();

            var viewModel = this.Mapper.Map<ProductDetailsViewModel>(product);

            return viewModel;
        }
    }
}
