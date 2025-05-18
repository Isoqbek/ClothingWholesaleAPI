using System.Collections.Generic;
using System.Threading.Tasks;
using ClothingWholesaleAPI.Models;

namespace ClothingWholesaleAPI.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderByIdAsync(int id);
        Task<Order> UpdateOrderStatusAsync(int id, string status);
    }
}