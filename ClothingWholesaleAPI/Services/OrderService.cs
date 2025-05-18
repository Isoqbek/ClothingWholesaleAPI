using System.Collections.Generic;
using System.Threading.Tasks;
using ClothingWholesaleAPI.Models;
using ClothingWholesaleAPI.Repositories;

namespace ClothingWholesaleAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _orderRepository.GetAllOrdersAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _orderRepository.GetOrderByIdAsync(id);
        }

        public async Task<Order> UpdateOrderStatusAsync(int id, string status)
        {
            // Validate status
            if (string.IsNullOrEmpty(status))
                return null;

            var validStatuses = new[] { "Yangi", "Tayyorlanmoqda", "Yuborilgan", "Yetkazib berilgan", "Bekor qilingan" };

            if (!validStatuses.Contains(status))
                return null;

            return await _orderRepository.UpdateOrderStatusAsync(id, status);
        }
    }
}