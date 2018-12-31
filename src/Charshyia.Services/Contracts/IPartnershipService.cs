using Charshyia.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Charshyia.Services.Contracts
{
    public interface IPartnershipService
    {
        Task CreatePartnershipRequest(CharshyiaUser fromUser, CharshyiaUser toUser, int shopId);

        void ResponseToParthership(int partnershipResponse, int partnershipId);

        List<Partnership> GetUserRequest(CharshyiaUser user);
    }
}
