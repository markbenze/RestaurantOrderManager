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
    .AddTransient<JwtAuthorizationMessageHandler>();

builder.Services
    .AddHttpClient("ApiClient", client =>
        client.BaseAddress = new Uri("http://localhost:5094/")
    )
    .AddHttpMessageHandler<JwtAuthorizationMessageHandler>();

builder.Services
    .AddScoped(sp =>
        sp.GetRequiredService<IHttpClientFactory>()
          .CreateClient("ApiClient")
    );

builder.Services
    .AddScoped<TableService>(sp =>
        new TableService(
            sp.GetRequiredService<HttpClient>()
        )
    )
    .AddScoped<OrderService>(sp =>
        new OrderService(
            sp.GetRequiredService<HttpClient>()
        )
    )
    .AddScoped<MenuService>(sp =>
        new MenuService(
            sp.GetRequiredService<HttpClient>()
        )
    )
    .AddScoped<CartService>(sp =>
        new CartService(
            sp.GetRequiredService<HttpClient>()
        )
    )
    .AddScoped<UserService>(sp =>
        new UserService(
            sp.GetRequiredService<HttpClient>()
        )
    );

await builder.Build().RunAsync();
