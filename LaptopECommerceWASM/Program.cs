using Blazored.LocalStorage;
using Blazored.Toast;
using LaptopECommerceWASM.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace LaptopECommerceWASM
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddBlazoredToast();
            builder.Services.AddTransient<ILaptopService, LaptopService>();
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IProcedureService, ProcedureService>();
            builder.Services.AddTransient<IOrderService, OrderService>();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<CartService>();
            // Thay vì fix cứng link, sử dụng luôn domain hiện tại để tránh mọi lỗi Mixed Content
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }
    }
}
