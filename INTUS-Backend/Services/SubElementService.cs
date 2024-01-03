using INTUS_Backend.Models;
using INTUS_Backend.Models.DTOs;
using INTUS_Backend.Repositories.Interfaces;
using INTUS_Backend.Services.Interfaces;

namespace INTUS_Backend.Services
{
    public class SubElementService : ISubElementService
    {
        private readonly IOrderRepository _orderRepository;

        public SubElementService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<bool> AddSubElement(string orderID, string windowName,  CreateSubElementDTO createSubElementDTO, string subElementId)
        {
            var order = await _orderRepository.GetOrderById(orderID);

            if (order != null)
            {
                // Find the window by name
                var window = order.Windows.FirstOrDefault(w => w.Name == windowName);

                if (window != null)
                {
                    // Find the element by number
                    var element = window.SubElements.FirstOrDefault(se => se.SubElementId.ToString() == subElementId);

                    if (element == null)
                    {
                        // Create a new sub-element
                        var subElementToAdd = new SubElement
                        {
                            //Element = createSubElementDTO.Element,
                            Height = createSubElementDTO.Height,
                            Width = createSubElementDTO.Width,
                            Type = createSubElementDTO.Type,
                        };
                        window.SubElements?.Add(subElementToAdd);

                        // Save the changes to the order
                        return await _orderRepository.UpdateOrder(order);
                    }
                }
            }

            return false;
        }


        public async Task<bool> RemoveSubElement(string orderID, string windowName, string elementNumber)
        {
            var order = await _orderRepository.GetOrderById(orderID);

            if (order != null)
            {
                // Find the window by name
                var window = order.Windows?.FirstOrDefault(w => w.Name == windowName);

                if (window != null)
                {
                    // Remove the sub-element by number
                    window.SubElements?.RemoveAll(se => se.SubElementId?.ToString() == elementNumber);

                    // Save the changes to the order
                    return await _orderRepository.UpdateOrder(order);
                }
            }

            return false;
        }


        public async Task<bool> UpdateSubElement(string orderID, string windowName, string elementId, UpdateSubElementDTO updateSubElementDTO)
        {
            var order = await _orderRepository.GetOrderById(orderID);

            if (order != null)
            {
                // Find the window by name
                var window = order.Windows?.FirstOrDefault(w => w.Name == windowName);

                if (window != null)
                {
                    // Find the sub-element by number
                    var subElement = window.SubElements?.FirstOrDefault(se => se.SubElementId?.ToString() == elementId);

                    if (subElement != null)
                    {
                        // Update sub-element properties using values from updateSubElementDTO
                        //subElement.Element = updateSubElementDTO.Element;
                        subElement.Width = updateSubElementDTO.Width;
                        subElement.Height = updateSubElementDTO.Height;
                        subElement.Type= updateSubElementDTO.Type;

                        // Save the changes to the order
                        return await _orderRepository.UpdateOrder(order);
                    }
                }
            }

            return false;
        }

    }
}
