using Charshyia.Data.Models;
using Charshyia.Services.Contracts;
using Charshyia.Services.Models.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Charshyia.Web.Controllers
{
    [Authorize]
    public class ProductsController : BaseController
    {
        private readonly IProductService productsService;
        //private readonly IMapper mapper;

        public ProductsController(UserManager<CharshyiaUser> userManager, IProductService productsService)
            : base(userManager)
        {
            this.productsService = productsService;
            //this.mapper = mapper;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateInputModel inputModel)
        {
            var productId = await this.productsService.CreateProductAsync(inputModel, this.CurrentUser.Id);

            return this.RedirectToAction("Details", new { id = productId });
        }

        public async Task<IActionResult> Details(int id)
        {
            var viewModel = await this.productsService.GetProductByIdAsync(id);

            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProductToShop(int productId, int shopId)
        {
            await this.productsService.AddProductToShop(productId, shopId);

            return this.RedirectToAction("Details", new { id = productId });
        }
    }
}
