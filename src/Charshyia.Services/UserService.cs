using AutoMapper;
using Charshyia.Data;
using Charshyia.Services.Contracts;
using Charshyia.Services.Models.Products;
using Charshyia.Services.Models.Shops;
using Charshyia.Services.Models.Users;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Charshyia.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IShopService shopService;

        public UserService(CharshyiaDbContext context, IMapper mapper, IShopService shopService)
            : base(context, mapper)
        {
            this.shopService = shopService;
        }

        public UserDetailsViewModel GetUserViewModel(string userId)
        {
            var user = this.DbContext
                .Users
                .Include(u => u.Products)
                .Include(u => u.Shops)
                    .ThenInclude(s => s.Shop)
                .FirstOrDefault(u => u.Id == userId);

            var viewModel = this.Mapper.Map<UserDetailsViewModel>(user);
            viewModel.Shops = this.Mapper.Map<List<ShopDetailsViewModel>>(user.Shops.Select(s => s.Shop));

            return viewModel;

        }
    }
}

//if (userId != null)
//{
//    var user = this.DbContext
//        .Users
//        .Include(u => u.Products)
//        .Include(u => u.Shops)
//            .ThenInclude(s => s.Shop)
//        .FirstOrDefault(u => u.Id == userId);

//    var userShops = user.Shops.Select(s => s.Shop).ToList();
//    var shopsViewModels = new List<ShopDetailsViewModel>();
//    foreach (var shop in userShops)
//    {
//        shopsViewModels.Add(this.shopService.GetShopByIdAsync(shop.Id).GetAwaiter().GetResult());
//    }

//    var viewModel = new UserDetailsViewModel
//    {
//        Username = user.UserName,
//        //Products = this.Mapper.Map<List<ProductDetailsViewModel>>(user.Products),
//        //Shops = shopsViewModels,
//        Email = user.Email,
//        PhoneNumer = user.PhoneNumber,
//        //Partnerships = this.DbContext
//        //            .Partnerships
//        //            .Include(x => x.Shop)
//        //            .Include(x => x.FromUser)
//        //            .Where(p => p.ToUserId == user.Id)
//        //            .ToList()
//    };

//    return viewModel;
//}
