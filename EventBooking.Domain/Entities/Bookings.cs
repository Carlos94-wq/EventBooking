using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.Domain.Entities
{
    public class Bookings
    {
        public int BookingID { get; set; }

        public int? UserID { get; set; }

        public int? EventID { get; set; }

        public int NumberOfSeats { get; set; }

        public DateTime? BookingDate { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
