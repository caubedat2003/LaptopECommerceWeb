using Blazored.LocalStorage;
using LaptopECommerce.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace LaptopECommerceWASM.Services
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginRequest loginRequest);
        Task Logout();
        Task<RegisterResponse> Register(RegisterRequest registerRequest);
        Task<RegisterResponse> ChangePassword(Guid id , ChangePasswordRequest request);
    }
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        public AuthService(HttpClient httpClient,
            AuthenticationStateProvider authenticationStateProvider,
            ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }
        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/login", loginRequest);
            var content = await result.Content.ReadAsStringAsync();
            var loginResponse = JsonSerializer.Deserialize<LoginResponse>(content,
                new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                });
            if (!result.IsSuccessStatusCode)
            {
                return loginResponse;
            }
            await _localStorage.SetItemAsync("authToken", loginResponse.Token);
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginRequest.UserName);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginResponse.Token);
            return loginResponse;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<RegisterResponse> Register(RegisterRequest registerRequest)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/register", registerRequest);
            var content = await result.Content.ReadAsStringAsync();
            var registerResponse = JsonSerializer.Deserialize<RegisterResponse>(content,
                new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                });
            return registerResponse;
        }

        public async Task<RegisterResponse> ChangePassword(Guid userId, ChangePasswordRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync($"/api/User/change-password/{userId}", request);

            if (response.IsSuccessStatusCode)
            {
                // Thành công, trả về phản hồi
                return await response.Content.ReadFromJsonAsync<RegisterResponse>();
            }
            else
            {
                // Lấy lỗi từ phản hồi
                var errorResponse = await response.Content.ReadFromJsonAsync<RegisterResponse>();
                return errorResponse ?? new RegisterResponse
                {
                    Successful = false,
                    Errors = new[] { "Không thể đổi mật khẩu. Lỗi không xác định." }
                };
            }
        }
    }
}
