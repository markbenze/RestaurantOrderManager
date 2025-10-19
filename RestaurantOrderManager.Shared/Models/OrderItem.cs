using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RestaurantOrderManager.Shared.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int MenuItemId { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; } = 1;
        public decimal Total => Price * Quantity;
        public int OrderId { get; set; }
        [JsonIgnore]
        public Order Order { get; set; }
    }
}
