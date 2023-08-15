using Dapper;
using EventBooking.Domain.Entities;
using EventBooking.Domain.Interfaces;
using System.Data;

namespace EventBooking.Percistance.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly IDbContext _dbContext;

        public BookingRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CanelBookingsByBookingId(int BookingId)
        {
            using (var conn = _dbContext.GetDbConnection())
            {
                var isCanceled = await conn.ExecuteAsync("CancelBooking", new { @BookingID = BookingId }, commandType: CommandType.StoredProcedure);
                return isCanceled;
            }
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

        public async Task<IEnumerable<Bookings>> GetBookingsByUserId(int UserId)
        {
            using (var conn = _dbContext.GetDbConnection())
            {
                var eventsByUserId = await conn.QueryAsync<Bookings>("GetUserBookings", new { @UserID = UserId }, commandType: CommandType.StoredProcedure);
                return eventsByUserId;
            }
        }
    }
}
