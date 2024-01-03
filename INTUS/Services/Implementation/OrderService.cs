using INTUS.DTOs;
using INTUS.Models;
using INTUS.Services.Interfaces;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using System.Net.Http;

namespace INTUS.Services.Implementation
{
    public class OrderService : IOrderService
    {
        
        public async Task<bool> AddOrder(Order order)
        {
            using(var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));



                // Serialize order if necessary (assuming System.Text.Json is available)
                var json = JsonSerializer.Serialize(order);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync("https://localhost:7052/api/Order", content); 

                if (response.IsSuccessStatusCode)
                {
                    return true; // Order added successfully
                }
                else
                {
                    
                    return false;
                }
            }
           
        }

        public Task<bool> CancelOrder(string orderId)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderById(string orderId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateOrder(UpdateOrderDTO updateOrderDTO, string orderID)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));



                // Serialize order if necessary (assuming System.Text.Json is available)
                var json = JsonSerializer.Serialize(updateOrderDTO);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PutAsync($"https://localhost:7052/api/Order/{orderID}", content);
                    

                if (response.IsSuccessStatusCode)
                {
                    return true; // Order updated successfully
                }
                else
                {

                    return false;
                }
            }
        }
    }
}
