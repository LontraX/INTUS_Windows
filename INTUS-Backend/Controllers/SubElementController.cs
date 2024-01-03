using INTUS_Backend.Models.DTOs;
using INTUS_Backend.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace INTUS_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubElementController : ControllerBase
    {
        private readonly ISubElementService _subElementService;

        public SubElementController(ISubElementService subElementService)
        {
            _subElementService = subElementService;
        }

        // POST api/orders/{orderID}/windows/{windowName}/subelements
        [HttpPost("{orderID}/windows/{windowName}/subelements/{subElementId}")]
        public async Task<IActionResult> AddSubElement(string orderID, string windowName, [FromBody] CreateSubElementDTO createSubElementDTO, string subElementId)
        {
            var result = await _subElementService.AddSubElement(orderID, windowName, createSubElementDTO,subElementId);

            if (result)
            {
                return Ok("Sub-element added successfully.");
            }

            return BadRequest("Failed to add sub-element.");
        }

        // DELETE api/orders/{orderID}/windows/{windowName}/subelements/{elementNumber}
        [HttpDelete("{orderID}/windows/{windowName}/subelements/{elementNumber}")]
        public async Task<IActionResult> RemoveSubElement(string orderID, string windowName, string elementNumber)
        {
            var result = await _subElementService.RemoveSubElement(orderID, windowName, elementNumber);

            if (result)
            {
                return Ok("Sub-element removed successfully.");
            }

            return NotFound("Sub-element not found or failed to remove.");
        }

        // PUT api/orders/{orderID}/windows/{windowName}/subelements/{elementNumber}
        [HttpPut("{orderID}/windows/{windowName}/subelements/{elementNumber}")]
        public async Task<IActionResult> UpdateSubElement(string orderID, string windowName, string elementNumber, [FromBody] UpdateSubElementDTO updateSubElementDTO)
        {
            var result = await _subElementService.UpdateSubElement(orderID, windowName, elementNumber, updateSubElementDTO);

            if (result)
            {
                return Ok("Sub-element updated successfully.");
            }

            return NotFound("Sub-element not found or failed to update.");
        }
    }
}
