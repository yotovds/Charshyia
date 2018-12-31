using AutoMapper;
using Charshyia.Data;
using Charshyia.Data.Models;
using Charshyia.Services.Contracts;
using Charshyia.Services.Models.Products;
using Charshyia.Services.Models.Shops;
using Charshyia.Services.Models.Users;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

            //var ppp = this.Mapper
            //         .Map<List<CharshyiaUser>>(shop.Producers.Select(x => x.Producer))
            //         .ToList();

            //var asdas = this.Mapper
            //        .Map<List<UserDetailsViewModel>>(ppp);

            var viewModel = new ShopDetailsViewModel
            {
                Id = shop.Id,
                Name = shop.Name,
                Products = this.Mapper
                    .Map<List<ProductDetailsViewModel>>(shop.Products.Select(x => x.Product))
                    .ToList(),
                Producers = this.Mapper
                    .Map<List<UserDetailsViewModel>>(this.Mapper
                        .Map<List<CharshyiaUser>>(shop.Producers.Select(x => x.Producer))
                        .ToList())
            };

            return viewModel;
        }

        //public async Task CreatePartnershipRequest(CharshyiaUser fromUser, CharshyiaUser toUser, int shopId)
        //{
        //    await this.DbContext
        //        .Partnerships
        //        .AddAsync(new Partnership
        //        {
        //            FromUser = fromUser,
        //            ToUser = toUser,
        //            ShopId = shopId,
        //            Status = PartnershipStatus.WaitingToResponse
        //        });

        //    await this.DbContext.SaveChangesAsync();
        //}

        //public void ResponseToParthership(int partnershipResponse, int partnershipId)
        //{
        //    var partnership = this.DbContext
        //        .Partnerships
        //        .Where(p => p.Id == partnershipId)
        //        .FirstOrDefault();

        //    switch (partnershipResponse)
        //    {
        //        case 0:
        //            partnership.Status = PartnershipStatus.Rejected;
        //            this.DbContext
        //                .Partnerships
        //                .Remove(partnership);

        //            this.DbContext.SaveChanges();
        //            break;

        //        case 1:
        //            partnership.Status = PartnershipStatus.Accepted;
        //            var shop = this.DbContext
        //                .Shops
        //                .Where(s => s.Id == partnership.ShopId)
        //                .FirstOrDefault();

        //            shop.Producers.Add(new ShopUser { ShopId = shop.Id, ProducerId = partnership.ToUserId });

        //            this.DbContext
        //                .Partnerships
        //                .Remove(partnership);

        //            this.DbContext.SaveChanges();
        //            break;
                
        //        default:
        //            break;
        //    }
        //}
    }
}
