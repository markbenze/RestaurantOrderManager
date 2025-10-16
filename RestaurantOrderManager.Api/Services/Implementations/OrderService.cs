using RestaurantOrderManager.Shared.Models;

namespace RestaurantOrderManager.Api.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private static int _nextOrderId = 4;

        private List<Order> _orders = new() {
            new Order
            {
                Id = 1,
                TableId = 1,
                State = OrderState.Completed,
                CartItems = new List<CartItem>
                {
                    new CartItem { Id = 1, Name = "Margherita Pizza", Price = 8.99m, Quantity = 2 },
                    new CartItem { Id = 2, Name = "Caesar Salad", Price = 6.49m, Quantity = 1 }
                },
                Total = 24.47m,
                CreatedAt = DateTime.Now.AddMinutes(-30)
            },
            new Order
            {
                Id = 2,
                TableId = 4,
                State = OrderState.InProgress,
                CartItems = new List<CartItem>
                {
                    new CartItem { Id = 3, Name = "Spaghetti Carbonara", Price = 10.99m, Quantity = 1 },
                    new CartItem { Id = 4, Name = "Grilled Chicken Sandwich", Price = 7.99m, Quantity = 1 },
                    new CartItem { Id = 5, Name = "Chocolate Lava Cake", Price = 5.49m, Quantity = 2 }
                },
                Total = 29.96m,
                CreatedAt = DateTime.Now.AddMinutes(-15)
            },
            new Order
            {
                Id = 3,
                TableId = 6,
                State = OrderState.Pending,
                CartItems = new List<CartItem>
                {
                    new CartItem { Id = 1, Name = "Margherita Pizza", Price = 8.99m, Quantity = 1 },
                    new CartItem { Id = 3, Name = "Spaghetti Carbonara", Price = 10.99m, Quantity = 1 }
                },
                Total = 19.98m,
                CreatedAt = DateTime.Now.AddMinutes(-5)
            }
        };

        public Order CreateOrder(int tableId, List<CartItem> cartItems)
        {
            var order = new Order
            {
                Id = _nextOrderId++%100,
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

        public List<Order> GetOrders() {
            return _orders;
        }
    
        public Order? GetOrder(int id)
        {
            var order = _orders.FirstOrDefault(o => o.Id == id);
            
            return order;
        }
    }
}
