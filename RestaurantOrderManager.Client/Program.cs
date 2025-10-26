using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using RestaurantOrderManager.Client;
using RestaurantOrderManager.Client.Authentication;
using RestaurantOrderManager.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, JwtAuthenticationStateProvider>();

builder.Services
    .AddScoped<MenuService>()
    .AddScoped<OrderService>()
    .AddScoped<CartService>()
    .AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5094/") })
    .AddScoped<TableService>(sp =>
        new TableService(
            sp.GetRequiredService<HttpClient>(),
            sp.GetRequiredService<IJSRuntime>()
        )
    );

await builder.Build().RunAsync();
