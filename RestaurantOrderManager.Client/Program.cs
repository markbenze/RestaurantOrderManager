using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RestaurantOrderManager.Client;
using RestaurantOrderManager.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services
    .AddScoped<TableService>()
    .AddScoped<MenuService>()
    .AddScoped<OrderService>()
    .AddScoped<CartService>()
    .AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5094/") });

await builder.Build().RunAsync();
