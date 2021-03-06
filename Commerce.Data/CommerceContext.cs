﻿using Commerce.Data.Configuration;
using Commerce.Data.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

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
        public IMongoCollection<Order> Orders => _mongoDatabase.GetCollection<Order>("Orders");
        public IMongoCollection<Category> Categories => _mongoDatabase.GetCollection<Category>("Categories");
        public IMongoCollection<Product> Products => _mongoDatabase.GetCollection<Product>("Products");
    }
}
