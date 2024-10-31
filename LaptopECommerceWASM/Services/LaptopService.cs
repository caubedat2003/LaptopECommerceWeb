using LaptopECommerce.Models;
using System.Net.Http.Json;

namespace LaptopECommerceWASM.Services
{
    public interface ILaptopService
    {
        Task<List<LaptopRequest>> GetLaptops();
        Task<LaptopRequest> GetLaptopDetail(Guid id);
        Task<bool> CreateLaptop(LaptopRequest request);
        Task<bool> UpdateLaptop(Guid id, LaptopRequest request);
        Task<bool> DeleteLaptop(Guid id);
    }
    public class LaptopService : ILaptopService
    {
        public HttpClient _httpClient;
        public LaptopService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateLaptop(LaptopRequest request)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/Laptop", request);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteLaptop(Guid id)
        {
            var result = await _httpClient.DeleteAsync($"/api/Laptop/{id}");
            return result.IsSuccessStatusCode;
        }

        public async Task<LaptopRequest> GetLaptopDetail(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<LaptopRequest>($"/api/Laptop/{id}");
            return result;
        }

        public async Task<List<LaptopRequest>> GetLaptops()
        {
            var result = await _httpClient.GetFromJsonAsync<List<LaptopRequest>>("/api/Laptop");
            return result;
        }

        public async Task<bool> UpdateLaptop(Guid id, LaptopRequest request)
        {
            var result = await _httpClient.PutAsJsonAsync($"/api/Laptop/{id}", request);
            return result.IsSuccessStatusCode;
        }
    }
}
