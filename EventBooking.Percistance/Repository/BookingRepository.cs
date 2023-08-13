using Dapper;
using EventBooking.Domain.Entities;
using EventBooking.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.Percistance.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly IDbContext _dbContext;

        public BookingRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreaateBooking(Bookings bookings)
        {
            using (var conn = _dbContext.GetDbConnection())
            {
                var parameters = new
                {
                    @UserID = bookings.UserID,
                    @EventID = bookings.EventID,
                    @NumberOfSeats = bookings.NumberOfSeats
                };
                var isBooked = await conn.ExecuteAsync("CreateBooking", parameters, commandType: CommandType.StoredProcedure);
                return isBooked;
            }
        }
    }
}
