using INTUS_Backend.Models.DTOs;

namespace INTUS_Backend.Services.Interfaces
{
    public interface ISubElementService
    {
        Task<bool> AddSubElement(string orderID, string windowName,  CreateSubElementDTO createSubElementDTO, string subElementId);
        Task<bool> RemoveSubElement(string orderID, string windowName, string elementNumber);
        Task<bool> UpdateSubElement(string orderID, string windowName, string elementNumber, UpdateSubElementDTO updateSubElementDTO);
    }
}
