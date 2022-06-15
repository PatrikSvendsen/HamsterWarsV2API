global using Shared.DataTransferObjects.Hamster;
global using Shared.DataTransferObjects.Match;
global using Shared.DataTransferObjects.User;
global using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using HamsterWarsV2.Client;
using HamsterWarsV2.Client.Extensions;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5001") });
builder.Services.ConfigureServices(builder.Configuration);
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();

await builder.Build().RunAsync();
