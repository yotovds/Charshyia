using Charshyia.Data.Models;
using Charshyia.Services.Contracts;
using Charshyia.Services.Models.Shops;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
            var shopId = await this.shopService.CreateShopAsync(inputModel, this.CurrentUser.Id);

            return this.RedirectToAction("Details", new { id = shopId });
        }

        public async Task<IActionResult> Details(int id)
        {
            var viewModel = await this.shopService.GetShopByIdAsync(id);
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SendRequestToProducer(string username, int shopId)
        {
            var fromUser = this.CurrentUser;
            var toUser = await this.userManager.FindByNameAsync(username);

            await this.shopService.CreatePartnershipRequest(fromUser, toUser, shopId);

            return this.RedirectToAction("Details", new { id = shopId });
        }

        [HttpPost]
        public IActionResult ResponseToPartnership(int partnershipResponse, int partnershipId)
        {
            this.shopService.ResponseToParthership(partnershipResponse, partnershipId);
            return RedirectToAction("Index", "Home");
        }
    }
}
