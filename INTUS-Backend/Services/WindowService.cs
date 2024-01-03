using INTUS_Backend.Models;
using INTUS_Backend.Models.DTOs;
using INTUS_Backend.Repositories.Interfaces;
using INTUS_Backend.Services.Interfaces;

namespace INTUS_Backend.Services
{
    public class WindowService : IWindowService
    {
        private readonly IOrderRepository _orderRepository;

        public WindowService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<bool> AddWindow(string orderID, CreateWindowDTO addWindowDTO)
        {
            var windowToAdd = new Window
            {
                Name = addWindowDTO.Name,
                QuantityOfWindows = addWindowDTO.QuantityOfWindows,
                TotalSubElements = addWindowDTO.TotalSubElements,
                //SubElements = addWindowDTO.SubElements?.Select(subElementDTO => new SubElement
                //{
                //    Element= subElementDTO.Element,
                //    Height = subElementDTO.Height,
                //    Width= subElementDTO.Width,
                //    Type = subElementDTO.Type
                   
                //}).ToList()
            };

            var order = await _orderRepository.GetOrderById(orderID);
            if (order != null)
            {
                order.Windows.Add(windowToAdd);
                return await _orderRepository.UpdateOrder(order);
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> RemoveWindow(string orderID, string windowName)
        {


            var order = await _orderRepository.GetOrderById(orderID);
            if (order != null)
            {
                order.Windows.RemoveAll(window => window.Name == windowName);
                return await _orderRepository.UpdateOrder(order);
                             
            }
            return false;
        }

        public async Task<bool> UpdateWindow(string orderID, string windowName, UpdateWindowDTO updateWindowDTO)
        {
            var order = await _orderRepository.GetOrderById(orderID);

            if (order != null)
            {
                // Find the window by name
                var window = order.Windows.FirstOrDefault(w => w.Name == windowName);

                if (window != null)
                {
                    // Update window properties using values from updateWindowDTO
                    window.Name = updateWindowDTO.Name;
                    window.QuantityOfWindows = updateWindowDTO.QuantityOfWindows;
                    window.TotalSubElements = updateWindowDTO.TotalSubElements;

                    // Update or add sub-elements
                    //window.SubElements = updateWindowDTO.SubElements?.Select(subElementDTO => new SubElement
                    //{
                    //    Element = subElementDTO.Element,
                    //    Height = subElementDTO.Height,
                    //    Width = subElementDTO.Width,
                    //    Type = subElementDTO.Type
                    //}).ToList();

                    // Save the changes to the order
                    return await _orderRepository.UpdateOrder(order);
                }
            }

            return false;
        }

    }
}
