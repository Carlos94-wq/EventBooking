using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.Domain.Entities
{
    public class Events
    {
        public int EventID { get; set; }

        public string EventName { get; set; }

        public DateTime? EventDate { get; set; }

        public int? VenueID { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool? IsDeleted { get; set; }

        public int AvailableSeats { get; set; }
    }
}
