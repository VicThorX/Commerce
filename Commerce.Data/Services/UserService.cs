using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Commerce.Data.Configuration;
using Commerce.Data.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Commerce.Data.Services
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService(IOptions<DatabaseConfiguration> configuration)
        {
            var mongoClient = new MongoClient(configuration.Value.ConnectionString);
            var dataBase = mongoClient.GetDatabase(configuration.Value.DatabaseName);

            _users = dataBase.GetCollection<User>("Users");
        }

        public async Task<List<User>> Get()
        {
            return await _users.Find(user => true).ToListAsync();
        }

        public async Task<User> Get(string id)
        {
            return await _users.Find(user => user.Id == id).FirstOrDefaultAsync();
        }

        public async Task<User> Create(User user)
        {
            await _users.InsertOneAsync(user);
            return user;
        }

        public async Task Update(string id, User userIn)
        {
            await _users.ReplaceOneAsync(user => user.Id == id, userIn);
        }

        public async Task Remove(string id)
        {
            await _users.DeleteOneAsync(user => user.Id == id);
        }

        public async Task Remove(User userOut)
        {
            await _users.DeleteOneAsync(user => user.Id == userOut.Id);
        }
    }
}
