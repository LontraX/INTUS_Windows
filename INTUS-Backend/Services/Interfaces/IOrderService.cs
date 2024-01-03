using INTUS_Backend.Models;
using INTUS_Backend.Models.DTOs;

namespace INTUS_Backend.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<bool> PlaceOrder(Order order);


        public Task<bool> UpdateOrder(UpdateOrderDTO updateOrderDTO, string orderID);


        public Task<bool> CancelOrder(string orderId);


        public Task<List<Order>> GetAllOrders();


        public Task<Order> GetOrderById(string orderId);
        

    }
}
