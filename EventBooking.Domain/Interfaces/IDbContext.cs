using System.Data;

namespace EventBooking.Domain.Interfaces
{
    public interface IDbContext
    {
        IDbConnection GetDbConnection();
    }
}
