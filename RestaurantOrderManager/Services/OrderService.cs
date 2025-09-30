using Microsoft.AspNetCore.Components;
using RestaurantOrderManager.Models;

namespace RestaurantOrderManager.Services;

public class OrderService
{
    private readonly MenuService _menuService;
    
    private List<Order> _orders = new List<Order>();
    
    public OrderService(MenuService menuService)
    {
        this._menuService = menuService;
    }

    public Order CreateOrder(int tableId, List<int> menuItemIds)
    {
        var order = new Order
        {
            Id = _orders.Count + 1,
            TableId = tableId,
            State = OrderState.Pending,
            MenuItems = menuItemIds
                .Select(id => _menuService.GetMenuItem(id))
                .Where(id => id != null)
                .ToList()!,
        };

        order.Total = order.MenuItems.Sum(item => item.Price); ;

        return order;
    }

    public void AddOrder(Order order)
    {
        _orders.Add(order);
    }
}