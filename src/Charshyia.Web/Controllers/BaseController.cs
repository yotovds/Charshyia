using Charshyia.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Charshyia.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly UserManager<CharshyiaUser> userManager;

        protected BaseController(UserManager<CharshyiaUser> userManager)
        {
            this.userManager = userManager;
        }

        protected CharshyiaUser CurrentUser
        {
             get
            {
                return this.userManager.GetUserAsync(this.User).GetAwaiter().GetResult();
            }
        }
    }
}
