using INTUS_Backend.Models;
using INTUS_Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace INTUS_Backend.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly APPDBContext _ctx;

        public OrderRepository(APPDBContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<bool> AddOrder(Order order)
        {
            await _ctx.Orders.AddAsync(order);
            return await _ctx.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteOrder(string Id)
        {
            var orderToDelete = await _ctx.Orders.FindAsync(Id);

            if (orderToDelete == null)
                return false;

            _ctx.Orders.Remove(orderToDelete);
            return await _ctx.SaveChangesAsync() > 0;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await _ctx.Orders?
                .Include(x => x.Windows)
                .ThenInclude(w => w.SubElements)
                .ToListAsync();
        }

        public async Task<Order> GetOrderById(string Id)
        {
            return await _ctx.Orders.FindAsync(Id);
        }

        public async Task<bool> UpdateOrder(Order order)
        {
            _ctx.Entry(order).State = EntityState.Modified;
            return await _ctx.SaveChangesAsync() > 0;
        }
    }
}
