using Microsoft.AspNetCore.Components;
using RestaurantOrderManager.Models;
using RestaurantOrderManager.Services;

namespace RestaurantOrderManager.Components.Pages;

public partial class Order
{
    [Inject]
    public OrderService OrderService { get; set; }

}