using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Charshyia.Services.Models;
using Charshyia.Data.Models;
using Microsoft.AspNetCore.Identity;
using Charshyia.Services.Contracts;
using Charshyia.Services.Models.Users;
using Charshyia.Services.Models.Home;

namespace Charshyia.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IUserService userService;

        public HomeController(UserManager<CharshyiaUser> userManager, IUserService userService) 
            : base(userManager)
        {
            this.userService = userService;
        }

        public IActionResult Index()
        {
            var viewModel = new HomeIndexViewModel
            {
                UserDetails = this.userService.GetUserViewModel(CurrentUser)
            };
            return View(viewModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
