using Commerce.API.Models;
using Commerce.Data.Entities;
using Commerce.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce.API.Mappers
{
    public class OrderModelToOrder : IMapper<OrderModel, Order>
    {
        private readonly IUserService _userService;

        public OrderModelToOrder(IUserService userService)
        {
            _userService = userService;
        }

        public void Fill(OrderModel input, Order output)
        {
            output.User = _userService.Get(input.UserId).Result;
            output.Concepts = input.Concepts;
            output.Total = input.Total;
        }

        public Order Map(OrderModel input)
        {
            var output = new Order()
            {
                User = _userService.Get(input.UserId).Result,
                Concepts = input.Concepts,
                Total = input.Total
            };

            return output;
        }
    }
}
