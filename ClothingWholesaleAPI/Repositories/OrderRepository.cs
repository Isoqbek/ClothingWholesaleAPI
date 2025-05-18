using System.Collections.Generic;
using System.Threading.Tasks;
using ClothingWholesaleAPI.Data;
using ClothingWholesaleAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ClothingWholesaleAPI.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task<Order> UpdateOrderStatusAsync(int id, string status)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
                return null;

            order.Status = status;
            await _context.SaveChangesAsync();

            return order;
        }
    }
}