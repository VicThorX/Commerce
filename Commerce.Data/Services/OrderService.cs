using Commerce.Data.Entities;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Commerce.Data.Services
{
    public class OrderService : IOrderService
    {
        private readonly ICommerceContext _commerceContext;

        public OrderService(ICommerceContext commerceContext)
        {
            _commerceContext = commerceContext;
        }

        public async Task<List<Order>> GetAll()
        {
            return await _commerceContext.Orders.Find(order => true).ToListAsync();
        }

        public async Task<Order> Get(string id)
        {
            return await _commerceContext.Orders.Find(order => order.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Order> Create(Order order)
        {
            await _commerceContext.Orders.InsertOneAsync(order);

            var userWithNewOrder = order.User;
            userWithNewOrder.Orders.Add(order);

            await _commerceContext.Users.ReplaceOneAsync(user => user.Id == order.User.Id, userWithNewOrder);

            return order;
        }

        public async Task Update(string id, Order orderIn)
        {
            await _commerceContext.Orders.ReplaceOneAsync(order => order.Id == id, orderIn);
        }

        public async Task Remove(string id)
        {
            await _commerceContext.Orders.DeleteOneAsync(order => order.Id == id);
        }

        public async Task Remove(Order orderOut)
        {
            await _commerceContext.Orders.DeleteOneAsync(order => order.Id == orderOut.Id);

            var userWithDeletedOrder = orderOut.User;
            userWithDeletedOrder.Orders.Remove(orderOut);

            await _commerceContext.Users.ReplaceOneAsync(user => user.Id == orderOut.User.Id, userWithDeletedOrder);
        }
    }
}
