
using Charshyia.Data.Models;
using Charshyia.Services.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Charshyia.Services.Contracts
{
    public interface IUserService
    {
        UserDetailsViewModel GetUserViewModel(CharshyiaUser user);
    }
}
