using INTUS.DTOs;
using INTUS.Models;


namespace INTUS.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<bool> AddOrder(Order order);


        public Task<bool> UpdateOrder(UpdateOrderDTO updateOrderDTO, string orderID);


        public Task<bool> CancelOrder(string orderId);

        public Task<Order> GetOrderById(string orderId);

    }
}
