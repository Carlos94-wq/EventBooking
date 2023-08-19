using EventBooking.Domain.Entities;
using System.Text.Json.Serialization;

namespace EventBooking.Application.Responses
{
    public class GetBookingsByUserIDResponse
    {
        public int BookingID { get; set; }

        [JsonIgnore]
        public int? EventID { get; set; }

        public DateTime? BookingDate { get; set; }

        public Events Events{ get; set; }

        public Venues Venues { get; set; }
    }
}
