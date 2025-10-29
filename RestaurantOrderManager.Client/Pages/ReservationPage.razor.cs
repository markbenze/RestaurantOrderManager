using Microsoft.AspNetCore.Components;
using RestaurantOrderManager.Client.Services;
using RestaurantOrderManager.Shared.Models;

namespace RestaurantOrderManager.Client.Pages;

public partial class ReservationPage : ComponentBase
{
    private List<Table> _tables = new();
    private bool ShowDialog = false;
    private int DialogTableId;
    private string? ErrorMessage;
    private string? SuccessMessage;

    private string ReservationName = string.Empty;
    private DateTime ReservationDate { get; set; } = DateTime.Today.AddDays(1);
    private string SelectedHour { get; set; } = "18:00";
    private List<string> AvailableHours { get; } = Enumerable.Range(12, 12).Select(h => $"{h:00}:00").ToList();


    [Inject]
    public TableService TableService { get; set; } = default!;

    [Inject]
    public ReservationService ReservationService { get; set; } = default!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = default!;


    protected override async Task OnInitializedAsync()
    {
        _tables = await TableService.GetTablesAsync();
    }

    private void ShowReservationDialog(int tableId)
    {
        DialogTableId = tableId;
        ReservationDate = DateTime.Today.AddDays(1);
        SelectedHour = "18:00";
        ReservationName = string.Empty;
        ShowDialog = true;
        ErrorMessage = null;
        SuccessMessage = null;
    }

    private async Task ReserveTable()
    {
        ErrorMessage = null;
        SuccessMessage = null;

        if (string.IsNullOrWhiteSpace(ReservationName))
        {
            ErrorMessage = "Please enter your name.";
            return;
        }

        if (!TimeSpan.TryParse(SelectedHour, out var time))
        {
            ErrorMessage = "Invalid hour selected.";
            return;
        }
        var reservationDateTime = ReservationDate.Date.Add(time);

        var result = await ReservationService.CreateReservationAsync(DialogTableId, reservationDateTime, ReservationName);
        if (result != null)
        {
            SuccessMessage = $"Table {DialogTableId} reserved for {reservationDateTime:g}.";
            var table = _tables.FirstOrDefault(t => t.Id == DialogTableId);
            if (table != null)
                table.Status = TableStatus.Reserved;
            ShowDialog = false;
        }
        else
        {
            ErrorMessage = "Failed to reserve table.";
        }
    }

    private void CloseDialog()
    {
        ShowDialog = false;
        ErrorMessage = null;
        SuccessMessage = null;
    }

    private void GoToReservationDetails(int tableId)
    {
        NavigationManager.NavigateTo($"/reservation/details/{tableId}");
    }
}