using Domin.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Interface
{
    public interface IOrderServices
    {

        public Task<Order> GetOrderDetailsById(int OrderId);
        public Task<IReadOnlyList<Order>> GetUserOrders(string UserId);
        public Task<Order>  CreateOrder(string UserId,   Address address);
    }
}
