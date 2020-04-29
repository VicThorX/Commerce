using Commerce.Data.Configuration;
using Commerce.Data.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commerce.Data
{
    public class CommerceContext : ICommerceContext
    {
        private readonly IMongoDatabase _mongoDatabase;

        public CommerceContext(IOptions<MongoDBConfig> configuration)
        {
            var mongoClient = new MongoClient(configuration.Value.ConnectionString);
            _mongoDatabase = mongoClient.GetDatabase(configuration.Value.DatabaseName);
        }

        public IMongoCollection<User> Users => _mongoDatabase.GetCollection<User>("Users");
    }
}
