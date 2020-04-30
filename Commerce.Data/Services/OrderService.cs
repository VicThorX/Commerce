using Commerce.Data.Models;
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
        }
    }
}
