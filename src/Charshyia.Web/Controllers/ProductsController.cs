using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Charshyia.Data.Models;
using Charshyia.Services.Contracts;
using Charshyia.Services.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Charshyia.Web.Controllers
{
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
        public IActionResult Create(ProductCreateInputModel inputModel)
        {
            //var product = this.mapper.Map<Product>(inputModel);
            //this.productsService.AddProduct(inputModel, CurrentUser.Id);

            //var viewModel = this.productsService.GetProductById(3);
            return this.View();
        }
    }
}
