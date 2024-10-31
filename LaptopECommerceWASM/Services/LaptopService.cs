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

        public Task<bool> CreateLaptop(LaptopRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteLaptop(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<LaptopRequest> GetLaptopDetail(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<LaptopRequest>> GetLaptops()
        {
            var result = await _httpClient.GetFromJsonAsync<List<LaptopRequest>>("/api/Laptop");
            return result;
        }

        public Task<bool> UpdateLaptop(Guid id, LaptopRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
