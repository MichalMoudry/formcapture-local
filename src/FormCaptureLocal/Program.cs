using Blazored.LocalStorage;
using FormCaptureLocal.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System.Threading.Tasks;

namespace FormCaptureLocal
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            _ = builder.Services.AddBlazoredLocalStorage()
                .AddLocalization(options => options.ResourcesPath = "Resources")
                .AddSingleton<IStringLocalizer<App>, StringLocalizer<App>>()
                .AddTransient<IDataAccess, IndexedDbDataAccess>();

            await builder.Build().RunAsync();
        }
    }
}