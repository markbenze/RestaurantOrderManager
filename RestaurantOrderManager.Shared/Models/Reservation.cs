using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderManager.Shared.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public DateTime ReservationTime { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
