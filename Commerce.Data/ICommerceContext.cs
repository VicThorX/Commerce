using Commerce.Data.Models;
using MongoDB.Driver;

namespace Commerce.Data
{
    public interface ICommerceContext
    {
        IMongoCollection<User> Users { get; }
    }
}