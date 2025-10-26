using Microsoft.EntityFrameworkCore;
using RestaurantOrderManager.Shared.Models;

namespace RestaurantOrderManager.Api.Data
{
    public class RestaurantDbContext: DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options) { }

        public DbSet<Table> Tables { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Table>().HasData(
                new Table { Id = 1, OrderNumber = 0, Status = TableStatus.Free },
                new Table { Id = 2, OrderNumber = 0, Status = TableStatus.Free },
                new Table { Id = 3, OrderNumber = 0, Status = TableStatus.Free },
                new Table { Id = 4, OrderNumber = 0, Status = TableStatus.Free },
                new Table { Id = 5, OrderNumber = 0, Status = TableStatus.Free },
                new Table { Id = 6, OrderNumber = 0, Status = TableStatus.Free }
            );

            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem
                {
                    Id = 1,
                    Name = "Margherita Pizza",
                    Price = 8.99m,
                    Description = "Classic pizza with tomato sauce, mozzarella, and basil."
                },
                new MenuItem
                {
                    Id = 2,
                    Name = "Caesar Salad",
                    Price = 6.49m,
                    Description = "Crisp romaine lettuce with Caesar dressing, croutons, and Parmesan cheese."
                },
                new MenuItem
                {
                    Id = 3,
                    Name = "Spaghetti Carbonara",
                    Price = 10.99m,
                    Description = "Pasta with eggs, cheese, pancetta, and pepper."
                },
                new MenuItem
                {
                    Id = 4,
                    Name = "Grilled Chicken Sandwich",
                    Price = 7.99m,
                    Description = "Grilled chicken breast with lettuce, tomato, and mayo on a toasted bun."
                },
                new MenuItem
                {
                    Id = 5,
                    Name = "Chocolate Lava Cake",
                    Price = 5.49m,
                    Description = "Warm chocolate cake with a gooey chocolate center."
                },
                new MenuItem
                {
                    Id = 6,
                    Name = "Sajtburger",
                    Price = 1.0m,
                    Description = "Csak a Sajtburger"
                }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, TableId = 1, State = OrderState.Completed, Total = 24.47m, CreatedAt = DateTime.Parse("2025-10-16T13:01:58") },
                new Order { Id = 2, TableId = 4, State = OrderState.InProgress, Total = 29.96m, CreatedAt = DateTime.Parse("2025-10-16T14:01:58") },
                new Order { Id = 3, TableId = 6, State = OrderState.Pending, Total = 19.98m, CreatedAt = DateTime.Parse("2025-10-16T15:01:58") },
                new Order { Id = 4, TableId = 2, State = OrderState.InProgress, Total = 22.97m, CreatedAt = DateTime.Parse("2025-10-16T16:01:58") },
                new Order { Id = 5, TableId = 5, State = OrderState.Completed, Total = 14.48m, CreatedAt = DateTime.Parse("2025-10-16T17:01:58") }
            );

            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem { Id = 1, OrderId = 1, MenuItemId = 1, Name = "Margherita Pizza", Price = 8.99m, Quantity = 2 },
                new OrderItem { Id = 2, OrderId = 1, MenuItemId = 2, Name = "Caesar Salad", Price = 6.49m, Quantity = 1 },
                
                new OrderItem { Id = 3, OrderId = 2, MenuItemId = 3, Name = "Spaghetti Carbonara", Price = 10.99m, Quantity = 1 },
                new OrderItem { Id = 4, OrderId = 2, MenuItemId = 4, Name = "Grilled Chicken Sandwich", Price = 7.99m, Quantity = 1 },
                new OrderItem { Id = 5, OrderId = 2, MenuItemId = 5, Name = "Chocolate Lava Cake", Price = 5.49m, Quantity = 2 },
               
                new OrderItem { Id = 6, OrderId = 3, MenuItemId = 1, Name = "Margherita Pizza", Price = 8.99m, Quantity = 1 },
                new OrderItem { Id = 7, OrderId = 3, MenuItemId = 3, Name = "Spaghetti Carbonara", Price = 10.99m, Quantity = 1 },
                
                new OrderItem { Id = 8, OrderId = 4, MenuItemId = 2, Name = "Caesar Salad", Price = 6.49m, Quantity = 2 },
                new OrderItem { Id = 9, OrderId = 4, MenuItemId = 4, Name = "Grilled Chicken Sandwich", Price = 7.99m, Quantity = 1 },
                new OrderItem { Id = 10, OrderId = 4, MenuItemId = 6, Name = "Fruit Juice", Price = 1.50m, Quantity = 3 },
                
                new OrderItem { Id = 11, OrderId = 5, MenuItemId = 5, Name = "Chocolate Lava Cake", Price = 5.49m, Quantity = 1 },
                new OrderItem { Id = 12, OrderId = 5, MenuItemId = 7, Name = "Espresso", Price = 2.99m, Quantity = 3 }
            );
        }
    }
}
