using Charshyia.Data.Models;
using Charshyia.Services.Contracts;
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
        protected readonly IDbService dbService;

        protected BaseController(UserManager<CharshyiaUser> userManager, IDbService dbService)
        {
            this.userManager = userManager;
            this.dbService = dbService; // TODO: Make it Property
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
