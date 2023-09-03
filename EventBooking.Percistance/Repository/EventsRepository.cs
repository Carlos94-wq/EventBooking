using Dapper;
using EventBooking.Domain.Entities;
using EventBooking.Domain.Interfaces;
using System.Data;

namespace EventBooking.Percistance.Repository
{
    public class EventsRepository : IEventsRepository
    {
        private readonly IDbContext _dbContext;

        public EventsRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddEvent(Events Event)
        {
            using (var conn = _dbContext.GetDbConnection())
            {
                var isAdded = await conn.ExecuteScalarAsync<int>("AddNewEvent", new { 
                    @EventName = Event.EventName,
                    @EventDate = Event.EventDate, 
                    @VenueId = Event.VenueID, 
                    @AvailableSeats = Event.AvailableSeats 
                }, 
                commandType: CommandType.StoredProcedure);

                return isAdded;
            }
        }

        public async Task<Events> GetEventDetails(int EventId)
        {
            using (var conn = _dbContext.GetDbConnection())
            {
                var parameters = new
                {
                    @EventID = EventId
                };
                var eventDetails = await conn.QueryAsync<Events>("GetEventDetails", parameters, commandType: CommandType.StoredProcedure);

                return eventDetails.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<Events>> GetEventsByVenueId(int VenueId)
        {
            using (var conn = _dbContext.GetDbConnection())
            {
                var EventsByVenueId = await conn.QueryAsync<Events>("GetEventsByVenueId", new { @VenueId = VenueId }, commandType: CommandType.StoredProcedure);
                return EventsByVenueId;
            }
        }

        public async Task<IEnumerable<Events>> GetUpcomingEvents()
        {
            using (var conn = _dbContext.GetDbConnection())
            {
                var UpcomingEvents = await conn.QueryAsync<Events>("GetUpcomingEvents");
                return UpcomingEvents;
            }
        }
    }
}
