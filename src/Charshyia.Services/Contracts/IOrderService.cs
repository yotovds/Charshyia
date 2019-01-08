using Charshyia.Data.Models;
using Charshyia.Services.Models.Orders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Charshyia.Services.Contracts
{
    public interface IOrderService
    {
        Task<int> CreateOrderAsync(int productId, int shopId, CharshyiaUser user);

        OrderDetailsViewModel GetOrderById(int orderId);

        void UserConfirmOrder(int orderId);

        List<OrderDetailsViewModel> GetCurrentProducerOrders(string producerId);

        int ProducerConfirmOrder(int orderId, CharshyiaUser user);

        int ShopConfirmOrder(int orderId, CharshyiaUser user);
    }
}
