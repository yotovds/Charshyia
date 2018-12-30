using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charshyia.Data.Models;
using Charshyia.Services.Contracts;
using Charshyia.Services.Models.Shops;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Charshyia.Web.Controllers
{
    public class ShopsController : BaseController
    {
        private readonly IShopService shopService;

        public ShopsController(UserManager<CharshyiaUser> userManager, IShopService shopService) 
            : base(userManager)
        {
            this.shopService = shopService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ShopCreateInputModel inputModel)
        {
            var shopId = await this.shopService.CreateShopAsync(inputModel, CurrentUser.Id);

            return this.RedirectToAction("Details", new { id = shopId });
        }

        public async Task<IActionResult> Details(int id)
        {
            var viewModel = await this.shopService.GetShopByIdAsync(id);
            return this.View(viewModel);
        }
    }
}
