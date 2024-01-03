using INTUS_Backend.Models;

namespace INTUS_Backend.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrders();
        Task<Order> GetOrderById(string Id);
        Task<bool> DeleteOrder(string Id);
        Task<bool> AddOrder(Order order);
        Task<bool> UpdateOrder(Order order);
    }
}
