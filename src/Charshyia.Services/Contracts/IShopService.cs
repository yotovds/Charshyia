using Charshyia.Data.Models;
using Charshyia.Services.Models.Shops;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Charshyia.Services.Contracts
{
    public interface IShopService
    {
        Task<int> CreateShopAsync(ShopCreateInputModel inputModel, string fouderId);

        Task<ShopDetailsViewModel> GetShopByIdAsync(int shopId);

        // TODO: Make this method async
        Task AddProductToShopAsync(int shopId, int productId);

        List<ShopDetailsViewModel> GetUserShops(string userId);

        //Task CreatePartnershipRequest(CharshyiaUser fromUser, CharshyiaUser toUser, int shopId);

        //void ResponseToParthership(int partnershipResponse, int partnershipId);
    }
}
