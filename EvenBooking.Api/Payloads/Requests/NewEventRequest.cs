namespace EvenBooking.Api.Payloads.Requests
{
    public record NewEventRequest(string EventName, DateTime EventDate, int VenueID, int AvailableSeats);
}
