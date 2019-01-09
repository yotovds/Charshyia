using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charshyia.Data.Models;
using Charshyia.Data.Models.Enums;
using Charshyia.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Charshyia.Web.Controllers
{
    public class SearchController : BaseController
    {
        private readonly ISearchService searchService;

        public SearchController(UserManager<CharshyiaUser> userManager, ISearchService searchService) 
            : base(userManager)
        {
            this.searchService = searchService;
        }

        [HttpPost]
        public IActionResult Search(string productName, ProductCategory category)
        {
            var sssss = this.searchService.Search(productName, category);
            this.ViewData["searchResult"] = sssss;
            return this.View();
        }
    }
}
