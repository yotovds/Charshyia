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
    public class CommentsController : BaseController
    {
        private readonly ICommnetService commnetService;

        public CommentsController(UserManager<CharshyiaUser> userManager, ICommnetService commnetService) 
            : base(userManager)
        {
            this.commnetService = commnetService;
        }

        [HttpPost]
        public IActionResult AddCommentToProduct(int productId, string commnetContent)
        {
            this.commnetService.AddCommentToProduct(productId, commnetContent);
            return this.RedirectToAction("Details", "Products", new { Id = productId });
        }

        [HttpPost]
        public IActionResult AddCommentToShop(int shopId, string commnetContent)
        {
            this.commnetService.AddCommentToShop(shopId, commnetContent);
            return this.RedirectToAction("Details", "Shops", new { Id = shopId });
        }
    }
}
