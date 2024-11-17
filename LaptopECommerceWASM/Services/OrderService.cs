using LaptopECommerce.Models;
using System.Net.Http.Json;

namespace LaptopECommerceWASM.Services
{
    public interface IOrderService
    {
        Task<bool> CreateOrder (OrderRequest request);
    }
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;
        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateOrder(OrderRequest request)
        {
            var result = await _httpClient.PostAsJsonAsync("api/order", request);
            return result.IsSuccessStatusCode;
        }
    }
}
