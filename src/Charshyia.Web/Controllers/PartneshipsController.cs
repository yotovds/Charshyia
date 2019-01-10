using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charshyia.Data.Models;
using Charshyia.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Charshyia.Web.Controllers
{
    public class PartneshipsController : BaseController
    {
        private readonly IPartnershipService partnershipService;

        public PartneshipsController(UserManager<CharshyiaUser> userManager, IPartnershipService partnershipService) 
            : base(userManager)
        {
            this.partnershipService = partnershipService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendRequestToProducer(string username, int shopId)
        {
            var fromUser = this.CurrentUser;
            var toUser = await this.userManager.FindByNameAsync(username);

            await this.partnershipService.CreatePartnershipRequest(fromUser, toUser, shopId);

            return this.RedirectToAction("Details", "Shops", new { id = shopId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ResponseToPartnership(int partnershipResponse, int partnershipId)
        {
            this.partnershipService.ResponseToParthership(partnershipResponse, partnershipId);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult ShowPartneshipsRequests()
        {
            this.ViewData["requests"] = this.partnershipService.GetUserRequest(CurrentUser);
            return this.View();
        }
    }
}
