﻿using System;
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
        private readonly ICommerceContext _commerceContext;

        public UserService(ICommerceContext commerceContext)
        {
            _commerceContext = commerceContext;
        }

        public async Task<List<User>> GetAll()
        {
            return await _commerceContext.Users.Find(user => true).ToListAsync();
        }

        public async Task<User> Get(string id)
        {
            return await _commerceContext.Users.Find(user => user.Id == id).FirstOrDefaultAsync();
        }

        public async Task<User> Create(User user)
        {
            await _commerceContext.Users.InsertOneAsync(user);

            return user;
        }

        public async Task Update(string id, User userIn)
        {
            await _commerceContext.Users.ReplaceOneAsync(user => user.Id == id, userIn);
        }

        public async Task Remove(string id)
        {
            await _commerceContext.Users.DeleteOneAsync(user => user.Id == id);
        }

        public async Task Remove(User userOut)
        {
            await _commerceContext.Users.DeleteOneAsync(user => user.Id == userOut.Id);
        }
    }
}
