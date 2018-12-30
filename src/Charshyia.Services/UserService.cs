using AutoMapper;
using Charshyia.Data;
using Charshyia.Data.Models;
using Charshyia.Services.Contracts;
using Charshyia.Services.Models.Users;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Charshyia.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(CharshyiaDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public UserDetailsViewModel GetUserViewModel(CharshyiaUser user)
        {            
            if (user != null)
            {
                var viewModel = this.Mapper.Map<UserDetailsViewModel>(user);
                viewModel.Partnerships = this.DbContext
                                .Partnerships
                                .Include(x => x.Shop)
                                .Include(x=>x.FromUser)
                                .Where(p => p.ToUserId == user.Id)
                                .ToList();
                return viewModel;
            }

            return null;
            
        }
    }
}
