using Dapper;
using EventBooking.Domain.Entities;
using EventBooking.Domain.Interfaces;
using System.Data;

namespace EventBooking.Percistance.Repository
{
    public class VenuesRespository : IVenuesRepository
    {
        private readonly IDbContext _dbContext;

        public VenuesRespository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Venues> GetVenuesDetail(int VenueId)
        {
            using (var conn = _dbContext.GetDbConnection())
            {
                var venueDetail = await conn.QueryAsync<Venues>("GetVenueDetails", new { @VenueID = VenueId }, commandType: CommandType.StoredProcedure);
                return venueDetail.FirstOrDefault();
            }
        }
    }
}
