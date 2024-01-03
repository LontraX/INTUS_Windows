using INTUS_Backend.Models;
using INTUS_Backend.Models.DTOs;
using INTUS_Backend.Repositories.Interfaces;
using INTUS_Backend.Services.Interfaces;

namespace INTUS_Backend.Services
{
    public class OrderService:IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IWindowService _windowService;
        private readonly ISubElementService _subElementService;

        public OrderService(IOrderRepository orderRepository, IWindowService windowService, ISubElementService subElementService)
        {
            _orderRepository = orderRepository;
            _windowService = windowService;
            _subElementService = subElementService;
        }

        public async Task<bool> PlaceOrder(Order order)
        {
            return await _orderRepository.AddOrder(order);
        }

        public async Task<bool> UpdateOrder(UpdateOrderDTO updateOrderDTO, string orderID)
        {
            var orderToUpdate = await _orderRepository.GetOrderById(orderID);
            orderToUpdate.Name = updateOrderDTO.Name;
            orderToUpdate.State = updateOrderDTO.State;
            return await _orderRepository.UpdateOrder(orderToUpdate);
        }

        public async Task<bool> CancelOrder(string orderId)
        {
            
            return await _orderRepository.DeleteOrder(orderId);
        }

        public async Task<List<Order>> GetAllOrders()
        {
            
            return await _orderRepository.GetAllOrders();
        }

        public async Task<Order> GetOrderById(string orderId)
        {
            
            return await _orderRepository.GetOrderById(orderId);
        }







    }
}
