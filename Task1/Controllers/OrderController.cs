using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Task1.Entities;
using Task1.Interfaces;

namespace Task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<Order>> Get()
        {
            var orders = await _orderRepository.GetOrders();
            if (orders == null)
            {
                return NotFound();
            }
            return Ok(orders);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<Order>> Create(Order order)
        {
            await _orderRepository.CreateAsync(order);
            return Ok(order);
        }

        [HttpPost("UpdateStatus/{orderId}")]
        public async Task<ActionResult<Order>> UpdateStatus(string orderId, [FromBody] string deliveryStatus)
        {
            var order = await _orderRepository.GetOrder(orderId);
            if (order == null)
            {
                return NotFound();
            }

            order.DeliveryStatus = deliveryStatus;
            await _orderRepository.UpdateAsync(order, orderId);

            return Ok(order);

        }

        [HttpGet("GetOrder/{year}")]
        public dynamic GetOrdersByYear(string year)
        {
            if (!string.IsNullOrEmpty(year))
            {
                return Ok(_orderRepository.GetOrdersByYear(Convert.ToInt32(year)).Result);
            }
            return Ok("");
        }


    }
}