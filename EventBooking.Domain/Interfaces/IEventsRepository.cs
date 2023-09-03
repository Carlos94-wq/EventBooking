using EventBooking.Domain.Entities;

namespace EventBooking.Domain.Interfaces
{
    public interface IEventsRepository
    {
        Task<IEnumerable<Events>> GetUpcomingEvents();
        Task<IEnumerable<Events>> GetEventsByVenueId(int VenueId);
        Task<Events> GetEventDetails(int EventId);      
        Task<int> AddEvent(Events Event);      
    }
}
