using Commerce.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Commerce.Data.Services
{
    public interface IUserService
    {
        Task<User> Create(User user);
        Task<List<User>> Get();
        Task<User> Get(string id);
        Task Remove(string id);
        Task Remove(User userOut);
        Task Update(string id, User userIn);
    }
}