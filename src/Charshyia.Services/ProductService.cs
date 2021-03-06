﻿using AutoMapper;
using Charshyia.Data;
using Charshyia.Data.Models;
using Charshyia.Services.Contracts;
using Charshyia.Services.Models.Products;
using Charshyia.Services.Models.Shops;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Charshyia.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IShopService shopService;

        public ProductService(CharshyiaDbContext context, IMapper mapper, IShopService shopService)
            : base(context, mapper)
        {
            this.shopService = shopService;
        }

        public async Task AddProductToShop(int productId, int shopId)
        {
            await this.shopService.AddProductToShopAsync(shopId, productId);
        }

        public async Task<int> CreateProductAsync(ProductCreateInputModel inputModel, string producerId)
        {
            var product = this.Mapper.Map<Product>(inputModel);
            product.ProducerId = producerId;

            var image = inputModel.Image;

            if (image != null)
            {
                Account account = new Account("dr8axwivq", "766763689436115", "I9KoG0cgt3QoCd3Dp2K2QpHMpsM");
                Cloudinary cloudinary = new Cloudinary(account);

                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(@"image.jpg", image.OpenReadStream())
                };
                var uploadResult = cloudinary.Upload(uploadParams);
                

                product.ImageUrl = uploadResult.Uri.ToString();
            }
            if (string.IsNullOrWhiteSpace(product.ImageUrl))
            {
                product.ImageUrl = "https://res.cloudinary.com/dr8axwivq/image/upload/v1546794753/test.jpg";
            }

            await this.DbContext.Products.AddAsync(product);
            await this.DbContext.SaveChangesAsync();

            return product.Id;
        }

        //public List<ProductDetailsViewModel> GetCurrentUserProducts(string userId)
        //{
        //    var products = this.DbContext
        //        .Products
        //        .Where(p => p.ProducerId == userId)
        //        .ToList();

        //    var productsViewModel = this.Mapper.Map<List<ProductDetailsViewModel>>(products);

        //    return productsViewModel;
        //}

        public async Task<ProductDetailsViewModel> GetProductByIdAsync(int productId)
        {
            var product = await this.DbContext
                .Products
                .Include(p => p.Producer)
                .Include(p => p.Shops)
                    .ThenInclude(s => s.Shop)
                .Include(p => p.Comments)
                .Where(p => p.Id == productId)
                .FirstOrDefaultAsync();

            var viewModel = this.Mapper.Map<ProductDetailsViewModel>(product);
            viewModel.Shops = this.Mapper.Map<List<ShopDetailsViewModel>>(product.Shops.Select(x => x.Shop));
            viewModel.Commnets = this.Mapper.Map<List<string>>(product.Comments.Select(x => x.CommentContent));

            return viewModel;
        }
    }
}
