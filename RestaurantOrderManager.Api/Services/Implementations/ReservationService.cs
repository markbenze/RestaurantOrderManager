using Microsoft.EntityFrameworkCore;
using RestaurantOrderManager.Api.Data;
using RestaurantOrderManager.Shared.Models;

namespace RestaurantOrderManager.Api.Services.Implementations
{
    public class ReservationService : IReservationService
    {
        private readonly RestaurantDbContext _appDbContext;

        public ReservationService(RestaurantDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Reservation> CreateReservationAsync(int tableId, DateTime reservationTime, string reservationName)
        {
            var reservation = new Reservation
            {
                TableId = tableId,
                ReservationTime = reservationTime,
                Name = reservationName,
                IsActive = true
            };

            _appDbContext.Reservations.Add(reservation);

            var table = await _appDbContext.Tables.FindAsync(tableId);
            if (table != null)
            {
                table.Status = TableStatus.Reserved;
                _appDbContext.Tables.Update(table);
            }

            await _appDbContext.SaveChangesAsync();
            return reservation;
        }

        public async Task<List<Reservation>> GetActiveReservationsAsync()
        {
            return await _appDbContext.Reservations
                .Where(r => r.IsActive)
                .ToListAsync();
        }
        public async Task<Reservation?> GetReservationByTableIdAsync(int tableId)
        {
            return await _appDbContext.Reservations
                .Where(r => r.TableId == tableId && r.IsActive)
                .FirstOrDefaultAsync();
        }
        public async Task<bool> CancelReservationAsync(int reservationId)
        {
            var reservation = await _appDbContext.Reservations.FindAsync(reservationId);
            if (reservation == null) return false;

            _appDbContext.Reservations.Remove(reservation);

            var table = await _appDbContext.Tables.FindAsync(reservation.TableId);
            if (table != null && table.Status == TableStatus.Reserved)
            {
                if (table.OrderNumber != 0) { 
                    table.Status = TableStatus.Occupied;
                }
                else
                {
                    table.Status = TableStatus.Free;
                }
                _appDbContext.Tables.Update(table);
            }

            await _appDbContext.SaveChangesAsync();
            return true;
        }
    }
}
