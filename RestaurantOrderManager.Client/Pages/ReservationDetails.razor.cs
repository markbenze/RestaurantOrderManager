using Microsoft.AspNetCore.Components;
using RestaurantOrderManager.Client.Services;
using RestaurantOrderManager.Shared.Models;

namespace RestaurantOrderManager.Client.Pages;

public partial class ReservationDetails : ComponentBase
{
    [Parameter]
    public int TableId { get; set; }

    [Inject]
    public ReservationService ReservationService { get; set; }

    [Inject]
    public TableService TableService { get; set; }

    [Inject] NavigationManager NavigationManager { get; set; }

    private Reservation? _reservation;
    private Table _table;
    private bool IsLoading = true;
    private bool IsCancelling = false;
    private string? CancelMessage;

    protected override async Task OnParametersSetAsync()
    {
        _reservation = await ReservationService.GetReservationByTableIdAsync(TableId);
        _table = await TableService.GetTableAsync(TableId);
        IsLoading = false;
    }

    protected async Task CancelReservation()
    {
        if (_reservation == null) return;
        IsCancelling = true;
        CancelMessage = null;
        var success = await ReservationService.CancelReservationAsync(_reservation.Id);
        if (success)
        {
            _reservation.IsActive = false;
            CancelMessage = "Reservation cancelled.";
        }
        else
        {
            CancelMessage = "Failed to cancel reservation.";
        }
        IsCancelling = false;
        StateHasChanged();
    }
    private async Task CreateOrder()
    {
        await ReservationService.CancelReservationAsync(_reservation.Id);
        NavigationManager.NavigateTo($"/order/{TableId}");
    }
}