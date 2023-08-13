
namespace EventBooking.Application.Responses
{
    public class GetUpcomingEventsResponse
    {
        public int EventID { get; set; }

        public string EventName { get; set; }

        public DateTime? EventDate { get; set; }

        public string EventStatus { get; set; }

        public bool IsSelectable { get; set; }
    }
}
