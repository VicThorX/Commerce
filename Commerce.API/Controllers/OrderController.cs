using Commerce.API.Mappers;
using Commerce.API.Models;
using Commerce.Data.Entities;
using Commerce.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Commerce.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;
        private readonly IMapper<OrderModel, Order> _orderMapper;

        public OrderController(
            ILogger<OrderController> logger,
            IOrderService orderService,
            IMapper<OrderModel, Order> orderMapper)
        {
            _logger = logger;
            _orderService = orderService;
            _orderMapper = orderMapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> Get()
        {
            return new ObjectResult(await _orderService.GetAll());
        }

        [HttpGet("{id:length(24)}", Name = "GetOrder")]
        public async Task<ActionResult<Order>> Get(string id)
        {
            var order = await _orderService.Get(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> Create(OrderModel orderModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var order = _orderMapper.Map(orderModel);

                    if (order.User == null)
                    {
                        return NotFound(new
                        {
                            Message = $"User with Id: {orderModel.UserId} not exist"
                        });
                    }

                    order.CreatedAt = DateTime.Now;

                    _logger.LogInformation("Creating new order of user: {0} {1}", order.User.Firstname, order.User.Lastname);

                    var createdOrder = await _orderService.Create(order);

                    return CreatedAtRoute("GetOrder", new { id = order.Id }, order);
                }

                return BadRequest("Order did not pass model validation");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating new Order.");
                return BadRequest(ex);
            }
        }

        [HttpPut("{id:length(24)}")]
        public async Task<ActionResult<Order>> Update(string id, OrderModel orderModel)
        {
            var orderToUpdate = await _orderService.Get(id);

            if (orderToUpdate == null)
            {
                return NotFound(new
                {
                    Message = $"There is no order with Id {id}"
                });
            }

            _orderMapper.Fill(orderModel, orderToUpdate);
            orderToUpdate.UpdateAt = DateTime.Now;

            await _orderService.Update(id, orderToUpdate);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<ActionResult<Order>> Delete(string id)
        {
            var order = await _orderService.Get(id);

            if (order == null)
            {
                return NotFound();
            }

            await _orderService.Remove(order);

            return NoContent();
        }
    }
}
