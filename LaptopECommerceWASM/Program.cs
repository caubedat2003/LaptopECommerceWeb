using LaptopECommerceWASM.Services;
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

            builder.Services.AddTransient<ILaptopService, LaptopService>();

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7001") });

            await builder.Build().RunAsync();
        }
    }
}
