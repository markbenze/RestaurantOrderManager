using System.Net.Http;
using System.Net.Http.Json;
using RestaurantOrderManager.Shared.Models;

namespace RestaurantOrderManager.Client.Services
{
    public class ReservationService
    {
        private readonly HttpClient _httpClient;

        public ReservationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Reservation?> CreateReservationAsync(int tableId, DateTime reservationTime, string reservationName)
        {
            var request = new CreateReservationRequest
            {
                TableId = tableId,
                ReservationTime = reservationTime,
                Name = reservationName
            };

            var response = await _httpClient.PostAsJsonAsync("api/reservation", request);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Reservation>();
            }
            return null;
        }

        public async Task<List<Reservation>> GetActiveReservationsAsync()
        {
            var reservations = await _httpClient.GetFromJsonAsync<List<Reservation>>("api/reservation/active");
            return reservations ?? new List<Reservation>();
        }
        public async Task<Reservation?> GetReservationByTableIdAsync(int tableId)
        {
            return await _httpClient.GetFromJsonAsync<Reservation>($"api/reservation/{tableId}");
        }

        public async Task<bool> CancelReservationAsync(int reservationId)
        {
            var response = await _httpClient.PostAsync($"api/reservation/cancel/{reservationId}", null);
            return response.IsSuccessStatusCode;
        }

        private class CreateReservationRequest
        {
            public int TableId { get; set; }
            public DateTime ReservationTime { get; set; }
            public string Name { get; set; } = string.Empty;
        }
    }
}