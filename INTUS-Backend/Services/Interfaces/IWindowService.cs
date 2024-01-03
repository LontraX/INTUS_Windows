using INTUS_Backend.Models.DTOs;

namespace INTUS_Backend.Services.Interfaces
{
    public interface IWindowService
    {
        Task<bool> AddWindow(string orderID, CreateWindowDTO addWindowDTO);
        Task<bool> RemoveWindow(string orderID, string windowName);
        Task<bool> UpdateWindow(string orderID, string windowName,UpdateWindowDTO updateWindowDTO);
    }
}
