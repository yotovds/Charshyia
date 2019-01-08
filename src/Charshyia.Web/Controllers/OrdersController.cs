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
    public class OrdersController : BaseController
    {
        private readonly IOrderService orderService;

        public OrdersController(UserManager<CharshyiaUser> userManager, IOrderService orderService) 
            : base(userManager)
        {
            this.orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> OrderProduct(int productId, int shopId)
        {
            var orderId = await this.orderService.CreateOrderAsync(productId, shopId, CurrentUser);
            return this.RedirectToAction("Details", new { id = orderId});
        }

        public IActionResult Details(int id)
        {
            var viewModel = this.orderService.GetOrderById(id);
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult UserConfirmOrder(int id)
        {
            this.orderService.UserConfirmOrder(id);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult ProducerConfirmOrder(int id)
        {            
            var shopId = this.orderService.ProducerConfirmOrder(id, CurrentUser);

            return RedirectToAction("Details", "Shops", new { id = shopId });
        }

        [HttpPost]
        public IActionResult ShopConfirmOrder(int id)
        {
            var shopId = this.orderService.ShopConfirmOrder(id, CurrentUser);

            return RedirectToAction("Details", "Shops", new { id = shopId });
        }
    }
}
