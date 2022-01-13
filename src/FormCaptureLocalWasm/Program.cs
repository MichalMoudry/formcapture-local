using FormCaptureLocalWasm;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;
using Microsoft.Extensions.Localization;
using FormCaptureLocalWasm.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
_ = builder.Services.AddBlazoredLocalStorage()
    .AddLocalization(options => options.ResourcesPath = "Resources")
    .AddSingleton<IStringLocalizer<App>, StringLocalizer<App>>()
    .AddScoped<IDataAccess, IndexedDbDataAccess>()
    .AddAntDesign();

await builder.Build().RunAsync();