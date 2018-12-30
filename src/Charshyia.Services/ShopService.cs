using AutoMapper;
using Charshyia.Data;
using Charshyia.Data.Models;
using Charshyia.Services.Contracts;
using Charshyia.Services.Models.Products;
using Charshyia.Services.Models.Shops;
using Charshyia.Services.Models.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charshyia.Services
{
    public class ShopService : BaseService, IShopService
    {
        public ShopService(CharshyiaDbContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }

        public async Task<int> CreateShopAsync(ShopCreateInputModel inputModel, string fouderId)
        {
            var shop = this.Mapper.Map<Shop>(inputModel);
            shop.FounderId = fouderId;
            await this.DbContext.Shops.AddAsync(shop);
            shop.Producers.Add(new ShopUser { ProducerId = shop.FounderId, ShopId = shop.Id });

            await this.DbContext.SaveChangesAsync();

            return shop.Id;
        }

        public async Task<ShopDetailsViewModel> GetShopByIdAsync(int shopId)
        {
            var shop = await this.DbContext
                .Shops
                .Include(s => s.Producers)
                    .ThenInclude(s => s.Producer)
                .Include(p => p.Products)
                    .ThenInclude(p => p.Product)
                    .ThenInclude(p => p.Producer)
                .Where(s => s.Id == shopId)
                .FirstOrDefaultAsync();

            var viewModel = new ShopDetailsViewModel
            {
                Id = shop.Id,
                Name = shop.Name,
                Products = this.Mapper
                    .Map<List<ProductDetailsViewModel>>(shop.Products.Select(x => x.Product))
                    .ToList(),
                Producers = this.Mapper
                    .Map<List<UserDetailsViewModel>>(shop.Producers.Select(x => x.Producer))
                    .ToList()
            };

            return viewModel;
        }
    }
}
