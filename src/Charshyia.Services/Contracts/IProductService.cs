using Charshyia.Data.Models;
using Charshyia.Services.Models;
using Charshyia.Services.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Charshyia.Services.Contracts
{
    public interface IProductService
    {
        Task<int> CreateProductAsync(ProductCreateInputModel inputModel, string producerId);

        Task<ProductDetailsViewModel> GetProductByIdAsync(int productId);

        Task AddProductToShop(int productId, int shopId);

        //List<ProductDetailsViewModel> GetCurrentUserProducts(string userId);
    }
}
