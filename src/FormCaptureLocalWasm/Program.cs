using Blazored.LocalStorage;
using FormCaptureLocalWasm;
using FormCaptureLocalWasm.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Localization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
_ = builder.Services.AddBlazoredLocalStorage()
    .AddLocalization(options => options.ResourcesPath = "Resources")
    .AddSingleton<IStringLocalizer<App>, StringLocalizer<App>>()
    .AddTransient<IDataAccess, IndexedDbDataAccess>()
    .AddScoped<IUserService, UserService>()
    .AddAntDesign();

await builder.Build().RunAsync();
