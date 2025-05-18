using System.Collections.Generic;
using System.Threading.Tasks;
using ClothingWholesaleAPI.Models;
using ClothingWholesaleAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ClothingWholesaleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IOrderService orderService, ILogger<OrdersController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        // GET: api/orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            _logger.LogInformation("Retrieving all orders");
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }

        // GET: api/orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            _logger.LogInformation($"Retrieving order with ID: {id}");
            var order = await _orderService.GetOrderByIdAsync(id);

            if (order == null)
            {
                _logger.LogWarning($"Order with ID: {id} not found");
                return NotFound();
            }

            return Ok(order);
        }

        // PUT: api/orders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderStatus(int id, [FromBody] OrderStatusUpdateDto statusUpdate)
        {
            if (statusUpdate == null || string.IsNullOrEmpty(statusUpdate.Status))
            {
                _logger.LogWarning("Invalid status update request");
                return BadRequest("Status is required");
            }

            _logger.LogInformation($"Updating order {id} status to {statusUpdate.Status}");
            var updatedOrder = await _orderService.UpdateOrderStatusAsync(id, statusUpdate.Status);

            if (updatedOrder == null)
            {
                _logger.LogWarning($"Order with ID: {id} not found or status invalid");
                return NotFound();
            }

            return Ok(updatedOrder);
        }
    }

    public class OrderStatusUpdateDto
    {
        public string Status { get; set; }
    }
}