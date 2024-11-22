using LaptopECommerce.Models;
using System.Net.Http.Json;

namespace LaptopECommerceWASM.Services
{
    public interface IProcedureService
    {
        Task<List<LaptopRequest>> GetAppleLaptops();
        Task<List<LaptopRequest>> GetSamsungLaptops();
        Task<List<LaptopRequest>> GetASUSLaptops();
        Task<List<LaptopRequest>> GetACERLaptops();
        Task<List<LaptopRequest>> GetMSILaptops();
        Task<List<LaptopRequest>> GetDellLaptops();
        Task<List<LaptopRequest>> GetLenovoLaptops();
        Task<List<LaptopRequest>> GetAlienwareLaptops();
        Task<List<UserDto>> GetShippers();
    }
    public class ProcedureService : IProcedureService
    {
        private readonly HttpClient _httpClient;
        public ProcedureService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<LaptopRequest>> GetACERLaptops()
        {
            return await _httpClient.GetFromJsonAsync<List<LaptopRequest>>("api/Procedures/GetACERs");
        }

        public async Task<List<LaptopRequest>> GetAlienwareLaptops()
        {
            return await _httpClient.GetFromJsonAsync<List<LaptopRequest>>("api/Procedures/GetAlienwares");
        }

        public async Task<List<LaptopRequest>> GetAppleLaptops()
        {
            return await _httpClient.GetFromJsonAsync<List<LaptopRequest>>("api/Procedures/GetApples");
        }

        public async Task<List<LaptopRequest>> GetASUSLaptops()
        {
            return await _httpClient.GetFromJsonAsync<List<LaptopRequest>>("api/Procedures/GetASUSs");
        }

        public async Task<List<LaptopRequest>> GetDellLaptops()
        {
            return await _httpClient.GetFromJsonAsync<List<LaptopRequest>>("api/Procedures/GetDells");
        }

        public async Task<List<LaptopRequest>> GetLenovoLaptops()
        {
            return await _httpClient.GetFromJsonAsync<List<LaptopRequest>>("api/Procedures/GetLenovos");
        }

        public async Task<List<LaptopRequest>> GetMSILaptops()
        {
            return await _httpClient.GetFromJsonAsync<List<LaptopRequest>>("api/Procedures/GetMSIs");
        }

        public async Task<List<LaptopRequest>> GetSamsungLaptops()
        {
            return await _httpClient.GetFromJsonAsync<List<LaptopRequest>>("api/Procedures/GetSamsungs");
        }

        public async Task<List<UserDto>> GetShippers()
        {
            return await _httpClient.GetFromJsonAsync<List<UserDto>>("api/Procedures/GetShippers");
        }
    }
}
