namespace EvenBooking.Api.Payloads.Requests
{
    public record CreateBookingRequest(int UserId, int EventId, int NumberOfSeats);
}
