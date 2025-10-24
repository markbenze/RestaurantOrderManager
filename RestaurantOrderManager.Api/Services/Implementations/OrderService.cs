using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestaurantOrderManager.Api.Data;
using RestaurantOrderManager.Shared.Models;
using System.Collections.Specialized;

namespace RestaurantOrderManager.Api.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly RestaurantDbContext _appDbContext;

        public OrderService(RestaurantDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Order> CreateAndAddOrderAsync(int tableId, List<CartItem> cartItems)
        {
            var order = BuildOrder(tableId, cartItems);

            await using var transaction = await _appDbContext.Database.BeginTransactionAsync();

            try { 
                var table = await _appDbContext.Tables.FirstOrDefaultAsync(t => t.Id == tableId);
                
                if(table == null)
                    throw new InvalidOperationException($"Table with id {tableId} now found");
                
                if(table.Status == TableStatus.Occupied)
                    throw new InvalidOperationException($"Table with id {tableId} has an active order");
            
                _appDbContext.Orders.Add(order);
                await _appDbContext.SaveChangesAsync();

                table.OrderNumber = order.Id;
                table.Status = TableStatus.Occupied;
                _appDbContext.Tables.Update(table);
                await _appDbContext.SaveChangesAsync();

                await transaction.CommitAsync();

                return order;
            }
            catch {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            _appDbContext.Orders.Add(order);
            await _appDbContext.SaveChangesAsync();

            return order;
        }

        public async Task<List<Order>> GetOrdersAsync() {
            return await _appDbContext.Orders
                .Include(o => o.OrderItems)
                .ToListAsync();
        }
    
        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _appDbContext.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.Id == id);
        }
    
        public async Task<Order> UpdateOrderStateAsync(int orderId, OrderState state)
        {
            await using var transaction = await _appDbContext.Database.BeginTransactionAsync();

            try
            {
                var order = await _appDbContext.Orders.FirstOrDefaultAsync(order => order.Id == orderId);

                if (order == null)
                    throw new InvalidOperationException($"Order with id {orderId} not found");

                if (order.State == state)
                    return order;

                if (state == OrderState.Completed || state == OrderState.Cancelled)
                {
                    order.State = state;
                    _appDbContext.Orders.Update(order);
                    await _appDbContext.SaveChangesAsync();

                    if (order.TableId != 0)
                    {
                        var table = await _appDbContext.Tables.FirstOrDefaultAsync(t => t.Id == order.TableId);
                        if (table is not null)
                        {
                            table.Status = TableStatus.Free;
                            table.OrderNumber = 0;
                            _appDbContext.Tables.Update(table);
                            await _appDbContext.SaveChangesAsync();
                        }
                    }
                }
                else {
                    order.State = state;
                    _appDbContext.Orders.Update(order);
                    await _appDbContext.SaveChangesAsync();
                }

                await transaction.CommitAsync();
                return order;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> RemoveOrderAsync(int id)
        {
            var order = await _appDbContext.Orders.FirstOrDefaultAsync(o => o.Id == id);
            if (order == null)
                return false;
            
            _appDbContext.Orders.Remove(order);
            await _appDbContext.SaveChangesAsync();
            
            return true;
        }

        private Order BuildOrder(int tableId, List<CartItem> cartItems)
        {
            var order = new Order
            {
                TableId = tableId,
                State = OrderState.Pending,
                OrderItems = cartItems.Select(item => new OrderItem
                {
                    MenuItemId = item.MenuItemId,
                    Name = item.Name,
                    Price = item.Price,
                    Quantity = item.Quantity
                }).ToList()
            };

            order.Total = order.OrderItems.Sum(item => item.Total);
            return order;
        }
    }
}
