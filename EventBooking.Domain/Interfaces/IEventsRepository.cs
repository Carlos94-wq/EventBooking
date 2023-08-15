using EventBooking.Domain.Entities;

namespace EventBooking.Domain.Interfaces
{
    public interface IEventsRepository
    {
        Task<IEnumerable<Events>> GetUpcomingEvents();
        Task<Events> GetEventDetails(int EventId);
    }
}
