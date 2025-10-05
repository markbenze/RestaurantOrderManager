using Microsoft.AspNetCore.Components;
using RestaurantOrderManager.Models;

namespace RestaurantOrderManager.Services;

public class OrderService
{
    private static int _nextOrderId = 1;
    
    private List<Order> _orders = new List<Order>();

    public Order CreateOrder(int tableId, List<CartItem> cartItems)
    {
        var order = new Order
        {
            Id = _nextOrderId++,
            TableId = tableId,
            State = OrderState.Pending,
            CartItems = cartItems.Select(item => new CartItem
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                Quantity = item.Quantity
            }).ToList()
        };

        order.Total = order.CartItems.Sum(item => item.Total);

        return order;
    }

    public void AddOrder(Order order)
    {
        _orders.Add(order);
    }

    public List<Order> GetOrders() => _orders.Select(o => new Order
        {
            Id = o.Id,
            TableId = o.TableId,
            Total = o.Total,
            State = o.State,
            CartItems = o.CartItems.ToList(),
            CreatedAt = o.CreatedAt
        }).ToList();
    }