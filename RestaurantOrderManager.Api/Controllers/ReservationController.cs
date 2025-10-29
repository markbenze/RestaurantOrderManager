using Microsoft.AspNetCore.Mvc;
using RestaurantOrderManager.Api.Services;
using RestaurantOrderManager.Shared.Models;

namespace RestaurantOrderManager.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost]
        public async Task<ActionResult<Reservation>> CreateReservation([FromBody] CreateReservationRequest request)
        {
            var reservation = await _reservationService.CreateReservationAsync(request.TableId, request.ReservationTime, request.Name);
            return Ok(reservation);
        }

        [HttpGet("active")]
        public async Task<ActionResult<List<Reservation>>> GetActiveReservations()
        {
            var reservations = await _reservationService.GetActiveReservationsAsync();
            return Ok(reservations);
        }

        [HttpGet("{tableId}")]
        public async Task<ActionResult<Reservation>> GetReservationByTableId(int tableId)
        {
            var reservation = await _reservationService.GetReservationByTableIdAsync(tableId);
            if (reservation == null)
                return NotFound();
            return Ok(reservation);
        }

        [HttpPost("cancel/{reservationId}")]
        public async Task<ActionResult> CancelReservation(int reservationId)
        {
            var success = await _reservationService.CancelReservationAsync(reservationId);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }

    public class CreateReservationRequest
    {
        public int TableId { get; set; }
        public DateTime ReservationTime { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}