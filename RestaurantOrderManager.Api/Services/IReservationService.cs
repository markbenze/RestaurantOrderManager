using RestaurantOrderManager.Shared.Models;
using System.Globalization;

namespace RestaurantOrderManager.Api.Services
{
    public interface IReservationService
    {
        Task<Reservation> CreateReservationAsync(int tableId, DateTime reservationTime, string reservationName);
        Task<List<Reservation>> GetActiveReservationsAsync();
        Task<bool> CancelReservationAsync(int reservationId);
        Task<Reservation?> GetReservationByTableIdAsync(int tableId);
    }
}
