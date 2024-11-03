using LaptopECommerce.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace LaptopECommerceWASM.Services
{
    public interface IUserService
    {
        Task<List<UserDto>> GetUsers();
        Task<UserDto> GetUserDetail(Guid id);
        Task<RegisterResponse> Create(UserDto request);
        Task<bool> Update(Guid id, UserDto request);
        Task<bool> Delete(Guid id);

    }
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<RegisterResponse> Create(UserDto request)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/User", request);
            var content = await result.Content.ReadAsStringAsync();
            var registerResponse = JsonSerializer.Deserialize<RegisterResponse>(content,
                new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                });
            return registerResponse;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _httpClient.DeleteAsync($"/api/User/{id}");
            return result.IsSuccessStatusCode;
        }

        public async Task<UserDto> GetUserDetail(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<UserDto>($"/api/User/{id}");
            return result;
        }

        public async Task<List<UserDto>> GetUsers()
        {
            var result = await _httpClient.GetFromJsonAsync<List<UserDto>>("/api/User");
            return result;
        }

        public async Task<bool> Update(Guid id, UserDto request)
        {
            var result = await _httpClient.PutAsJsonAsync($"/api/User/{id}", request);
            return result.IsSuccessStatusCode;
        }
    }
}
