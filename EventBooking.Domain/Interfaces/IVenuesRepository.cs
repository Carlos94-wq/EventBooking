using EventBooking.Domain.Entities;

namespace EventBooking.Domain.Interfaces
{
    public interface IVenuesRepository
    {
        Task<Venues> GetVenuesDetail(int VenueId);
        Task<IEnumerable<Venues>> GetVenue(string VenueName, string Adress);
    }

}
