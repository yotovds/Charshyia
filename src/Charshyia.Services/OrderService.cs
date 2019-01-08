using AutoMapper;
using Charshyia.Data;
using Charshyia.Data.Models;
using Charshyia.Data.Models.Enums;
using Charshyia.Services.Contracts;
using Charshyia.Services.Models.Orders;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Charshyia.Services
{
    public class OrderService : BaseService, IOrderService
    {
        public OrderService(CharshyiaDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<int> CreateOrderAsync(int productId, int shopId, CharshyiaUser user)
        {
            var order = new Order
                {
                    ProductId = productId,
                    ShopId = shopId,
                    UserId = user.Id,
                    Status = OrderStatus.Created
                };

            await this.DbContext.Orders.AddAsync(order);
            await this.DbContext.SaveChangesAsync();

            return order.Id;
        }

        public List<OrderDetailsViewModel> GetCurrentProducerOrders(string producerId)
        {
            var orders = this.DbContext
                .Orders
                .Include(o => o.User)
                .Where(o => o.Product.ProducerId == producerId)
                .ToList();

            var viewModel = this.Mapper.Map<List<OrderDetailsViewModel>>(orders);

            return viewModel;
        }

        public OrderDetailsViewModel GetOrderById(int orderId)
        {
            var order = this.DbContext
                .Orders
                .Include(o => o.Product)
                    .ThenInclude(p => p.Producer)
                .Include(o => o.Shop)
                .Include(o => o.User)
                .Where(o => o.Id == orderId)
                .FirstOrDefault();

            var viewModel = this.Mapper.Map<OrderDetailsViewModel>(order);

            return viewModel;
        }

        public int ProducerConfirmOrder(int orderId, CharshyiaUser user)
        {
            var order = this.DbContext
                .Orders
                .Where(o => o.Id == orderId && o.Product.ProducerId == user.Id)
                .FirstOrDefault();
            order.Status = OrderStatus.ProducerConfirmed;
            this.DbContext.SaveChanges();

            return order.ShopId;
        }

        public int ShopConfirmOrder(int orderId, CharshyiaUser user)
        {
            var order = this.DbContext
                .Orders
                .Where(o => o.Id == orderId && o.Product.ProducerId == user.Id)
                .FirstOrDefault();
            order.Status = OrderStatus.ShopConfirmed;
            this.DbContext.SaveChanges();

            return order.ShopId;
        }

        public void UserConfirmOrder(int orderId)
        {
            this.DbContext
                .Orders
                .Where(o => o.Id == orderId)
                .FirstOrDefault()
                .Status = OrderStatus.UserConfrimed;

            this.DbContext.SaveChanges();
        }
    }
}
