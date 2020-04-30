using Commerce.Data.Entities;
using MongoDB.Driver;

namespace Commerce.Data
{
    public interface ICommerceContext
    {
        IMongoCollection<User> Users { get; }
        IMongoCollection<Order> Orders { get; }
        IMongoCollection<Category> Categories { get; }
        IMongoCollection<Product> Products { get; }
    }
}