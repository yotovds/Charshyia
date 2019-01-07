using Charshyia.Data.Models;
using Charshyia.Services.Contracts;
using Charshyia.Services.Models;
using Charshyia.Services.Models.Home;
using Charshyia.Services.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
            if (this.CurrentUser != null)
            {
                var viewModel = this.userService.GetUserViewModel(this.CurrentUser.Id);

                return View(viewModel);
            }

            return this.View(new UserDetailsViewModel());            
        }

        public IActionResult About()
        {
            this.ViewData["Message"] = "Your application description page.";

            return this.View();
        }

        public IActionResult Contact()
        {
            this.ViewData["Message"] = "Your contact page.";

            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
