using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.Application.Responses
{
    public class GetVenueByIdResponse
    {
        public int VenueID { get; set; }

        public string VenueName { get; set; }

        public string Address { get; set; }
    }
}
