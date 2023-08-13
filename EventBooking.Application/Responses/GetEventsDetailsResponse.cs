using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.Application.Responses
{
    public class GetEventsDetailsResponse
    {
        public int EventID { get; set; }

        public string EventName { get; set; }

        public DateTime? EventDate { get; set; }

        public GetVenueByIdResponse VenueDetails { get; set; }

    }
}
