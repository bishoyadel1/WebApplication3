using Domin.Context;
using Domin.Entities.Order;
using Infrastucture.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Repository
{
    public class OrderServices : IOrderServices
    {
        private readonly StoreDbContext storeDbContext;
        private readonly IBasketRepostiroy basketRepostiroy;

        public OrderServices(StoreDbContext _storeDbContext, IBasketRepostiroy _basketRepostiroy )
        {
            storeDbContext = _storeDbContext;
            this.basketRepostiroy = _basketRepostiroy;
        }

        public async Task<Order> CreateOrder(string UserId, Address address)
        {
            var order = new Order();
            order.UserId = UserId;
            order.Address = address;
            var items = new List<OrderItem>();
            var basket = await basketRepostiroy.GetAllWithItems(UserId);
            var OrderItem = new OrderItem();
            if (basket != null )
            {
                foreach (var item in basket)
                {
                    OrderItem.ProductId = item.ProductId;
                    OrderItem.ProductName = item.Product.ProductName;
                    OrderItem.Quntity = item.ProductCount;
                    OrderItem.Price = item.Product.Price;
                    items.Add(OrderItem);
                }
                order.Items = items;
                order.TotalPrice = items.Sum(i => (i.Price * i.Quntity));
                storeDbContext.Orders.Add(order);
                var result = await storeDbContext.SaveChangesAsync();
                if (result > 0 )
                {
                    basketRepostiroy.DeleteUserBasket(UserId);

                    return order;
                }
            }
          
           
             

            return null;
           
        }

        public async Task<Order> GetOrderDetailsById(int OrderId)
         => await storeDbContext.Orders.Where(i => i.Id == OrderId).Include(o => o.Items).Include(a => a.Address).FirstOrDefaultAsync(); 

        public async Task<IReadOnlyList<Order>> GetUserOrders(string UserId)
         => await storeDbContext.Orders.Where(k=>k.UserId == UserId). Include(o => o.Items).Include(a => a.Address).ToArrayAsync();
    }
}
