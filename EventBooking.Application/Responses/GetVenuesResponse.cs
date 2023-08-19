

using EventBooking.Domain.Entities;

namespace EventBooking.Application.Responses
{
    public class GetVenuesResponse
    {
        public int VenueID { get; set; }

        public string VenueName { get; set; }

        public string Address { get; set; }

        public IEnumerable<GetEventsDetailsResponse> Events{ get; set; }
    }
}
