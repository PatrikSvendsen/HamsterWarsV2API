global using Shared.DataTransferObjects.Hamster;
global using Shared.DataTransferObjects.Match;
using HamsterWarsV2.Client;
using HamsterWarsV2.Client.Extensions;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5001") });
builder.Services.ConfigureServices(builder.Configuration);

await builder.Build().RunAsync();
