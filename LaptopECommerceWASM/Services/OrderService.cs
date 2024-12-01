using LaptopECommerce.Models;
using System.Net.Http.Json;

namespace LaptopECommerceWASM.Services
{
    public interface IOrderService
    {
        Task<List<OrderRequest>> GetOrders();
        Task<bool> CreateOrder (OrderRequest request);
        Task<List<OrderResponse>> GetOrderDetails();
        Task<bool> AssignShipper (Guid id, AssignShipperRequest request);
        Task<OrderResponse> GetOrderById (Guid id);
        Task<bool> UpdateStatus(Guid id, StatusRequest request);
        Task<List<OrderResponse>> GetMyOrder(Guid id);
    }
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;
        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> AssignShipper(Guid id, AssignShipperRequest request)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/order/{id}/assign", request);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> CreateOrder(OrderRequest request)
        {
            var result = await _httpClient.PostAsJsonAsync("api/order", request);
            return result.IsSuccessStatusCode;
        }

        public async Task<List<OrderResponse>> GetMyOrder(Guid id) // Customer Id
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<OrderResponse>>($"/api/Order/MyOrder/{id}");

                return result ?? new List<OrderResponse>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi gọi API: {ex.Message}");
                return new List<OrderResponse>(); 
            }
        }

        public async Task<OrderResponse> GetOrderById(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<OrderResponse>($"/api/Order/{id}");
            return result;
        }

        public async Task<List<OrderResponse>> GetOrderDetails()
        {
            var result = await _httpClient.GetFromJsonAsync<List<OrderResponse>>("/api/Order/Details");
            return result;
        }

        public async Task<List<OrderRequest>> GetOrders()
        {
            var result = await _httpClient.GetFromJsonAsync<List<OrderRequest>>("/api/Order");
            return result;
        }

        public async Task<bool> UpdateStatus(Guid id, StatusRequest request)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/order/{id}/status", request);
            return result.IsSuccessStatusCode;
        }
    }
}
