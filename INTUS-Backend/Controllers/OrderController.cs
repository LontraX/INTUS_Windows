using INTUS_Backend.Models.DTOs;
using INTUS_Backend.Services;
using INTUS_Backend.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace INTUS_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder([FromBody] CreateOrderDTO orderDto)
        {
            // Basic input validations in the controller
            if (orderDto == null || string.IsNullOrEmpty(orderDto.Name) || string.IsNullOrEmpty(orderDto.State))
            {
                return BadRequest("Invalid order data. Please provide valid name and state.");
            }

            // Additional controller-level checks...

            // Delegate to the service layer for business rule validations
            try
            {
                var order = orderDto.ToOrder();
                var result = await _orderService.PlaceOrder(order);
                if (result)
                {
                    return StatusCode(201,order);
                }
                else
                {
                    return BadRequest("Could not place order");
                }
               
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing the order.");
            }
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrderById(string orderId)
        {
            if (string.IsNullOrEmpty(orderId))
            {
                return BadRequest("Invalid order ID. Please provide a valid order ID.");
            }

            try
            {
                var order = await _orderService.GetOrderById(orderId);
                if (order == null)
                {
                    return NotFound("Order not found.");
                }

                return Ok(order);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving the order.");
            }
        }
    

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                var orders = await _orderService.GetAllOrders();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving orders.");
            }
        }

        [HttpDelete("{orderId}")]
        public async Task<IActionResult> CancelOrder(string orderId)
        {
            if (string.IsNullOrEmpty(orderId))
            {
                return BadRequest("Invalid order ID. Please provide a valid order ID.");
            }

            try
            {
                var result = await _orderService.CancelOrder(orderId);
                return StatusCode(200, "Order deleted");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while canceling the order.");
            }
        }

       
        [HttpPut("{orderID}")]
        public async Task<IActionResult> UpdateOrder(string orderID,[FromBody] UpdateOrderDTO updateOrderDTO)
        {
            var result = await _orderService.UpdateOrder(updateOrderDTO, orderID);

            if (result)
            {
                return Ok("Order updated successfully.");
            }

            return NotFound("Order not found or failed to update.");
        }
        
    }
}
