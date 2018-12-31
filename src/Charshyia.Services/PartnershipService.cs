using AutoMapper;
using Charshyia.Data;
using Charshyia.Data.Models;
using Charshyia.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charshyia.Services
{
    public class PartnershipService : BaseService, IPartnershipService
    {
        public PartnershipService(CharshyiaDbContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }

        //public Task CreatePartnershipRequest(CharshyiaUser fromUser, CharshyiaUser toUser, int shopId)
        //{
        //    throw new NotImplementedException();
        //}

        //public void ResponseToParthership(int partnershipResponse, int partnershipId)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task CreatePartnershipRequest(CharshyiaUser fromUser, CharshyiaUser toUser, int shopId)
        {
            await this.DbContext
                .Partnerships
                .AddAsync(new Partnership
                {
                    FromUser = fromUser,
                    ToUser = toUser,
                    ShopId = shopId,
                    Status = PartnershipStatus.WaitingToResponse
                });

            await this.DbContext.SaveChangesAsync();
        }

        public List<Partnership> GetUserRequest(CharshyiaUser user)
        {
            var partnerships = new List<Partnership>();

            if (user != null)
            {
                 partnerships = this.DbContext
                .Partnerships
                .Include(p => p.Shop)
                .Include(p => p.FromUser)
                .Where(p => p.ToUserId == user.Id)
                .ToList();

                return partnerships;
            }

            return null;
        }

        public void ResponseToParthership(int partnershipResponse, int partnershipId)
        {
            var partnership = this.DbContext
                .Partnerships
                .Where(p => p.Id == partnershipId)
                .FirstOrDefault();

            switch (partnershipResponse)
            {
                case 0:
                    partnership.Status = PartnershipStatus.Rejected;
                    this.DbContext
                        .Partnerships
                        .Remove(partnership);

                    this.DbContext.SaveChanges();
                    break;

                case 1:
                    partnership.Status = PartnershipStatus.Accepted;
                    var shop = this.DbContext
                        .Shops
                        .Where(s => s.Id == partnership.ShopId)
                        .FirstOrDefault();

                    shop.Producers.Add(new ShopUser { ShopId = shop.Id, ProducerId = partnership.ToUserId });

                    this.DbContext
                        .Partnerships
                        .Remove(partnership);

                    this.DbContext.SaveChanges();
                    break;

                default:
                    break;
            }
        }
    }
}
