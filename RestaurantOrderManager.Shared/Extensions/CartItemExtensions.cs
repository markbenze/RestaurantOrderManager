using RestaurantOrderManager.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderManager.Shared.Extensions
{
    public static class CartItemExtensions
    {
        public static CartItem ToCartItem(this MenuItem menuItem, int quantity = 1) {
            return new CartItem
            {
                Id = menuItem.Id,
                Name = menuItem.Name,
                Price = menuItem.Price,
                Quantity = quantity
            };
        }
    }
}
