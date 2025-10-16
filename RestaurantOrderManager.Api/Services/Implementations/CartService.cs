using Microsoft.AspNetCore.Mvc;
using RestaurantOrderManager.Shared.Models;
using System.Collections.Concurrent;

namespace RestaurantOrderManager.Api.Services.Implementations
{
    public class CartService : ICartService
    {
        private ConcurrentDictionary<int, Cart> _carts = new();

        public Cart GetCart(int tableId) { 
            return _carts.GetOrAdd(tableId, new Cart { TableId = tableId, Items = new List<CartItem>()});
        }

        public decimal GetCartTotal(int tableId) {
            var cart = GetCart(tableId);
            return cart.Items.Sum(i => i.Total);
        }

        public void AddItem(int tableId, CartItem cartItem)
        {
            var cart = _carts.GetOrAdd(tableId, new Cart { TableId = tableId, Items = new List<CartItem>() });

            var existingItem = cart.Items.FirstOrDefault(i => i.Id == cartItem.Id);
            
            if (existingItem != null) {
                existingItem.Quantity += cartItem.Quantity;
            } else {
                cart.Items.Add(cartItem);
            }
        }

        public void RemoveItem(int tableId, int itemId)
        {
            if(_carts.TryGetValue(tableId, out var cart)) {
                cart.Items.RemoveAll(i => i.Id == itemId);
            }
        }

        public void ClearCart(int tableId)
        {
            _carts[tableId] = new Cart { TableId = tableId, Items = new List<CartItem>() };
        }

        public void IncreaseQuantity(int tableId, int itemId) {
            if (_carts.TryGetValue(tableId, out var cart)) {
                var item = cart.Items.FirstOrDefault(i => i.Id == itemId);
                if (item != null) {
                    item.Quantity++;
                }
            }
        }

        public void DecreaseQuantity(int tableId, int itemId) {
            if (_carts.TryGetValue(tableId, out var cart))
            {
                var item = cart.Items.FirstOrDefault(i => i.Id == itemId);
                if (item != null)
                {
                    if (item.Quantity > 1)
                    {
                        item.Quantity--;
                    }
                    else { 
                        RemoveItem(tableId, itemId);
                    }
                }

            }
        }
    }
}
