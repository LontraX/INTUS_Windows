using INTUS_Backend.Models.DTOs;
using INTUS_Backend.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace INTUS_Backend.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class WindowController : ControllerBase
    {
        private readonly IWindowService _windowService;

        public WindowController(IWindowService windowService)
        {
            _windowService = windowService;
        }

        // POST api/orders/{orderID}/windows
        [HttpPost("{orderID}/windows")]
        public async Task<IActionResult> AddWindow(string orderID, [FromBody] CreateWindowDTO createWindowDTO)
        {
            var result = await _windowService.AddWindow(orderID, createWindowDTO);

            if (result)
            {
                return Ok("Window added successfully.");
            }

            return BadRequest("Failed to add window.");
        }

        // DELETE api/orders/{orderID}/windows/{windowName}
        [HttpDelete("{orderID}/windows/{windowName}")]
        public async Task<IActionResult> RemoveWindow(string orderID, string windowName)
        {
            var result = await _windowService.RemoveWindow(orderID, windowName);

            if (result)
            {
                return Ok("Window removed successfully.");
            }

            return NotFound("Window not found or failed to remove.");
        }

        // PUT api/orders/{orderID}/windows/{windowName}
        [HttpPut("{orderID}/windows/{windowName}")]
        public async Task<IActionResult> UpdateWindow(string orderID, string windowName, [FromBody] UpdateWindowDTO updateWindowDTO)
        {
            var result = await _windowService.UpdateWindow(orderID, windowName, updateWindowDTO);

            if (result)
            {
                return Ok("Window updated successfully.");
            }

            return NotFound("Window not found or failed to update.");
        }
    }
}
